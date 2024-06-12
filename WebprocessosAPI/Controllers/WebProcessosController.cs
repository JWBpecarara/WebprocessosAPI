using Microsoft.AspNetCore.Mvc;
using WebprocessosAPI.DAO;
using WebprocessosAPI.Model;

namespace WebprocessosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebprocessosAPIController : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            try
            {
                WebProcessosDAO DAO = new WebProcessosDAO();

                var Result = DAO.LoginDao(login);

                if (Result == null)
                    return Unauthorized(); 

                return Ok(Result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{ClienteID}")]
        public IActionResult GetServicoCliente(int ClienteID)
        {
            try
            {
                WebProcessosDAO DAO = new WebProcessosDAO();
                var result = DAO.GetServicoClienteDao(ClienteID);

                if (result == null)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Adicione um log de erro ou alguma forma de registrar o erro
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("AprovarServico")]
        public IActionResult AprovarServicoCliente([FromBody] int CodServicoVinculado)
        {
            try
            {
                WebProcessosDAO DAO = new WebProcessosDAO();

                var Result = DAO.AprovarServicoClienteDao(CodServicoVinculado);

                if (Result == null)
                    return BadRequest();

                return Ok(Result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("ReprovarServico")]
        public IActionResult ReprovarServicoCliente([FromBody] int CodServicoVinculado)
        {
            try
            {
                WebProcessosDAO DAO = new WebProcessosDAO();

                var Result = DAO.ReprovarServicoCliente(CodServicoVinculado);

                if (Result == null)
                    return BadRequest();

                return Ok(Result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("ServicoEtapa")]
        public IActionResult GetServicoEtapaCliente([FromBody] int CodServico)
        {
            try
            {
                WebProcessosDAO DAO = new WebProcessosDAO();

                var Result = DAO.GetServicoEtapaClienteDao(CodServico);

                if (Result == null)
                    return BadRequest();

                return Ok(Result);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}