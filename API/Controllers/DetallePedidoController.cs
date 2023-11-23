using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class DetallePedidoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetallePedidoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetallePedidoDto>>> Get1()
    {
        var results = await _unitOfWork.DetallePedidos
                                    .GetAllAsync();
        return _mapper.Map<List<DetallePedidoDto>>(results);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetallePedidoDto>> Get2(int id)
    {
        var result = await _unitOfWork.DetallePedidos.GetByIdAsync(id);
        return _mapper.Map<DetallePedidoDto>(result);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetallePedido>> Post(DetallePedidoDto resultDto)
    {
        var result = _mapper.Map<DetallePedido>(resultDto);
        this._unitOfWork.DetallePedidos.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
        {
            return BadRequest();
        }
        resultDto.CodigoPedido = result.CodigoPedido;
        return CreatedAtAction(nameof(Post), new { id = resultDto.CodigoPedido }, resultDto);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetallePedido>> Put(int id, [FromBody] DetallePedidoDto resultDto)
    {
        var result = _mapper.Map<DetallePedido>(resultDto);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.DetallePedidos.Update(result);
        await _unitOfWork.SaveAsync();
        return result;
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _unitOfWork.DetallePedidos.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.DetallePedidos.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}