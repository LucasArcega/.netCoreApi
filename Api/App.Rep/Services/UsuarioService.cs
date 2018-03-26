using App.Rep.DAL;
using App.Rep.Entities;
using App.Rep.IServices;
using App.Rep.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using App.Lib.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;

namespace App.Rep.Services
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IUsuarioDAL usuarioDAL;
        private TokenConfigurations tokenConfigurations;
        private SigningConfigurations signingConfiguration;
        private IConfiguration configuration;
        

        public UsuarioService(IUsuarioDAL usuarioDAL, [FromServices] TokenConfigurations tokenConfigurations, [FromServices] SigningConfigurations signingConfiguration, IConfiguration configuration)
        {
            this.usuarioDAL = usuarioDAL;
            this.tokenConfigurations = tokenConfigurations;
            this.signingConfiguration = signingConfiguration;
            this.configuration = configuration;
        }
        
        public Usuario Carregar(int id)
        {
            return this.usuarioDAL.Carregar(id);
        }

        public Usuario Carregar(string login)
        {
            return this.usuarioDAL.Carregar(login);
        }


        public void Salvar(Usuario entidade)
        {
            if (entidade.IdUsuario > 0)
            {
                usuarioDAL.Atualizar(entidade);
            }                
            else
            {
                entidade.Senha = CriptografarSenha(entidade.Senha);
                usuarioDAL.Inserir(entidade);
            }                            
        }


        public void NotificarCadastro(Usuario entidade)
        {
            SmtpClient client = new SmtpClient(configuration["MailSettings:Smtp"]);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(configuration["MailSettings:Email"], configuration["MailSettings:Password"]);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(configuration["MailSettings:Email"]);
            mailMessage.To.Add(entidade.Login);

            mailMessage.Body = "body";
            mailMessage.Subject = "Cadastro realizado com sucesso!";
            client.Send(mailMessage);
        }
        public List<Usuario> Listar()
        {
            return this.usuarioDAL.Listar();
        }

        public void Deletar(int id)
        {
            this.usuarioDAL.Excluir(id);
        }

        public List<Usuario> Listar(Filtro filtro)
        {
            return this.usuarioDAL.Listar(filtro);
        }

        /// <summary>
        /// Realiza a autenticação de um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private LoginModel Autenticar(Usuario usuario)
        {            
            LoginModel loginModel = new LoginModel();
            ClaimsIdentity identity = 
                new ClaimsIdentity(new GenericIdentity(usuario.Login, "Login"),new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login)
                   });

            loginModel.Created = DateTime.Now;
            loginModel.Expiration = loginModel.Created + TimeSpan.FromSeconds(tokenConfigurations.Seconds);
            loginModel.Authenticated = true;

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = this.tokenConfigurations.Audience,
                SigningCredentials = this.signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = loginModel.Created,
                Expires = loginModel.Expiration
            });
            loginModel.Token  = handler.WriteToken(securityToken);
            loginModel.Authenticated = true;

            return loginModel;
        }

        /// <summary>
        /// Recebe o a instancia do usuário enviado pela requisição, e seu equivalente encontrado no banco de dados
        /// </summary>
        /// <param name="usuarioEntrada"></param>
        /// <param name="usuarioDb"></param>
        /// <returns></returns>
        /// 
        public LoginModel Login(Usuario usuarioEntrada, Usuario usuarioDb)
        {
            LoginModel loginModel = new LoginModel();
            loginModel.Authenticated = false;
            var senhaValida = VerificarSenha(usuarioEntrada.Senha, usuarioDb.Senha);

            if (senhaValida)
            {
                loginModel = this.Autenticar(usuarioDb);
            }

            return loginModel;
        }
        /// <summary>
        /// Responsável por executar a criptografia da senha de um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private string CriptografarSenha(string senha)
        {
            HashAlgorithm algoritmo = SHA512.Create();
            var valorCodificado = Encoding.UTF8.GetBytes(senha);

            var senhaCifrada = algoritmo.ComputeHash(valorCodificado);
            var sb = new StringBuilder();

            foreach (var caractere in senhaCifrada)
            {

                sb.Append(caractere.ToString("X2"));

            }

            return sb.ToString();

        }



        public bool VerificarSenha(string senhaDigitada, string senhaCadastrada)
        {
            return CriptografarSenha(senhaDigitada) == senhaCadastrada;
        }

    }
}
