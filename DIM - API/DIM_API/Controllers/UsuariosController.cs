using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DIM_API.Data;
using DIM_API.Models;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;

namespace DIM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public UsuariosController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuarios usuarios)
        {
            if (id != usuarios.UsuarioID)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios(Usuarios usuarios)
        {
            string codVerificacion = GenerarYEnviarMailConCodigoVerificacion(usuarios.Email,usuarios.Nombre);
            usuarios.CodigoVerificacion = codVerificacion;
            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios", new { id = usuarios.UsuarioID }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios>> DeleteUsuarios(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return usuarios;
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioID == id);
        }

        private string GenerarYEnviarMailConCodigoVerificacion(string email,string nombre)
        {
            int codigoVerificacion = new Random().Next(1,999999);
            string codVerificacionString = codigoVerificacion.ToString("000000");


            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("usuarios.confirmacion@dim.com", "DIM", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add(email); //Correo destino?
            correo.Subject = "Activá tu cuenta en DIM"; //Asunto
            correo.Body = GetBodyEmail(codVerificacionString, nombre); //Mensaje del correo
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 25; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("dim.confirmacion@gmail.com", "dimutn2021");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);

            return codVerificacionString;
        }

        private string GetBodyEmail(string codVerificacion,string nombre) {

            return "<tbody>" +
                       "<tr>" +
                          "<td>&nbsp;</td>" +
                       "</tr>" +
                       "<tr>" +
                          "<td height='25'>&nbsp;</td>" +
                       "</tr>" +
                       "<tr>" +
                          "<td height='25'>" +
                             "<table width='90%' border='0' align='center' cellpadding='0' cellspacing='0'>" +
                                "<tbody>" +
                                    "<tr>" +
                                      "<img src='https://i.postimg.cc/g2QHmbmB/Titulo-Mail.png' style='width: width: 700px;height: auto;padding: 15px;'>" +
                                  "</tr>" +
                                   "<tr>" +
                                       "<td height='25'><span style='font-family:Arial; font-size:14px; color:#5a5a5a'>" + nombre + ", ingresa el siguente código en la aplicación y activa tu cuenta en  DIM.<br><br></span></td>" +
                                   "</tr>" +
                                   "<tr>" +
                                      "<td bgcolor='#eaeaea' align='center' style='border:solid 1px #9ac400; padding:15px'><span style='font-family:Arial; color:#565656; font-size:30px; font-weight:bold'>" + codVerificacion + "</span> </td>" +
                                   "</tr>" +
                                "</tbody>" +
                             "</table>" +
                          "</td>" +
                       "</tr>" +
                    "</tbody>";
          
        }


    }
}
