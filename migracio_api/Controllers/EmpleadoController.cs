using AutoMapper;
using migracio_api.Repository;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Nomina_API.Filters;
using migracio_api.Repository.IRepository;
using SharedModels;
using SharedModels.Dto;

namespace migracio_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepo;
        private readonly ILogger<EmpleadoController> _logger;
        private readonly IMapper _mapper;
        public EmpleadoController(IEmpleadoRepository empleadoRepo, ILogger<EmpleadoController> logger, IMapper mapper)
        {
            _empleadoRepo = empleadoRepo;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        // [MyLoggingAsync("AllEmpleado")]
        // [MyLogging("AllEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetEmpleado()
        {
            try
            {
                _logger.LogInformation("Obteniendo los empleados");

                var empleados = await _empleadoRepo.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<EmpleadoDto>>(empleados));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los empleados: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener los empleados.");
            }
        }

        [HttpGet("{id}")]
        // [MyLoggingAsync("GetSingleEmpleado|")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadoDto>> GetEmpleado(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"ID del empleado  no válido: {id}");
                return BadRequest("ID del empleado no válido");
            }

            try
            {
                _logger.LogInformation($"Obteniendo empleado con ID: {id}");

                var empleado = await _empleadoRepo.GetById(id);

                if (empleado == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("Empleado no encontrado.");
                }

                return Ok(_mapper.Map<EmpleadoDto>(empleado));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener el empleado.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmpleadoDto>> PostEmpleado(EmpleadoCreateDto createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Se recibió un empleado nulo en la solicitud.");
                return BadRequest("El empleado no puede ser nulo.");
            }

            try
            {
                _logger.LogInformation($"Creando un nuevo empleado con nombre: {createDto.Nombre}");

                // Verificar si el Empleado ya existe
                var existingEmpleado = await _empleadoRepo
                    .GetAsync(s => s.Nombre != null && s.Nombre.ToLower()
                    == createDto.Nombre.ToLower());

                if (existingEmpleado != null)
                {
                    _logger.LogWarning($"El Empleado con nombre '{createDto.Nombre}' ya existe.");
                    ModelState.AddModelError("NombreExiste", "¡El Empleado con ese nombre ya existe!");
                    return BadRequest(ModelState);
                }

                // Verificar la validez del modelo
                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de Empleado no es válido.");
                    return BadRequest(ModelState);
                }

                // Crear al nuevo Empleado
                var newEmpleado = _mapper.Map<Empleado>(createDto);

                await _empleadoRepo.CreateAsync(newEmpleado);

                _logger.LogInformation($"Nuevo Empleado '{createDto.Nombre}' creado con ID: " +
                    $"{newEmpleado.EmpleadoId}");
                return CreatedAtAction(nameof(GetEmpleado), new { id = newEmpleado.EmpleadoId }, newEmpleado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear un nuevo Empleado: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al crear un nuevo Empleado.");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutEmpleado(int id, EmpleadoUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.EmpleadoId)
            {
                return BadRequest("Los datos de entrada no son válidos o " +
                    "el ID del Empleado no coincide.");
            }
            try
            {
                _logger.LogInformation($"Actualizando Empleado con ID: {id}");

                var existingEmpleado = await _empleadoRepo.GetById(id);
                if (existingEmpleado == null)
                {
                    _logger.LogInformation($"No se encontró ningún Empleado con ID: {id}");
                    return NotFound("El estudiante no existe.");
                }

                // Actualizar solo las propiedades necesarias del estudiante existente
                _mapper.Map(updateDto, existingEmpleado);

                await _empleadoRepo.SaveChangesAsync();

                _logger.LogInformation($"Empleado con ID {id} actualizado correctamente.");

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await _empleadoRepo.ExistsAsync(e => e.EmpleadoId == id))
                {
                    _logger.LogWarning($"No se encontró ningún Empleado con ID: {id}");
                    return NotFound("El Empleado no se encontró durante la actualización");
                }
                else
                {
                    _logger.LogError($"Error de concurrencia al actualizar al Empleado " +
                        $"con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error interno del servidor al actualizar al Empleado.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar al Empleado: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al actualizar al Empleado.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando Empleado con ID: {id}");

                var student = await _empleadoRepo.GetById(id);
                if (student == null)
                {
                    _logger.LogInformation($"Eliminando Empleado con ID: {id}");
                    return NotFound("Empleado no encontrado.");
                }

                await _empleadoRepo.DeleteAsync(student);

                _logger.LogInformation($"Empleado con ID {id} eliminado correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el Empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Se produjo un error al eliminar el Empleado.");
            }
        }

        /*[HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchEmpleado(int id,
            JsonPatchDocument<EmpleadoUpdateDto> patchDto)
        {
            if (id <= 0)
            {
                return BadRequest("ID de Empleado no válido.");
            }
            try
            {
                _logger.LogInformation($"Aplicando el parche al Empleado con ID: {id}");

                var empleado = await _empleadoRepo.GetById(id);
                if (empleado == null)
                {
                    _logger.LogWarning($"No se encontró ningún Empleado con ID: {id}");
                    return NotFound("El Empleado no se encontró");
                }

                var EmpleadoDto = _mapper.Map<EmpleadoUpdateDto>(empleado);

                //patchDto.ApplyTo(EmpleadoDto, ModelState); (original)
                patchDto.ApplyTo(EmpleadoDto);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de Empleado después de aplicar el parche" +
                        " no es válido.");
                    return BadRequest(ModelState);
                }

                _mapper.Map(EmpleadoDto, empleado); // Aplicar cambios al objeto original

                using (var transaction = await _empleadoRepo.BeginTransactionAsync())
                {
                    try
                    {
                        await _empleadoRepo.SaveChangesAsync();
                        transaction.Commit();
                        _logger.LogInformation($"Parche aplicado correctamente al Empleado " +
                            $"con ID: {id}");
                        return NoContent();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        if (!await _empleadoRepo.ExistsAsync(e => e.EmpleadoId == id))
                        {
                            _logger.LogWarning($"No se encontró ningún Empleado con ID: {id}");
                            return NotFound();
                        }
                        else
                        {
                            _logger.LogError($"Error de concurrencia al aplicar el parche al Empleado " +
                                $"con ID: {id}. Detalles: {ex.Message}");
                            return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error interno del servidor al aplicar el parche al Empleado.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error al aplicar el parche al Empleado con ID {id}: " +
                            $"{ex.Message}");
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "Error interno del servidor al aplicar el parche al Empleado.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al aplicar el parche al Empleado con ID {id}: " +
                           $"{ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al aplicar el parche al Empleado.");

            }
        }*/
    }
}
