using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListAPI.Data;
using TodoListAPI.Models;

namespace TodoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public TodoItemsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest("Os dados da tarefa não podem estar vazios.");
            }

            // Adicione a nova tarefa ao contexto do banco de dados
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            // Retorne uma resposta 201 Created com o objeto criado
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(Guid id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(Guid id, TodoItem updatedItem)
        {
            if (id != updatedItem.Id)
            {
                return BadRequest("O ID fornecido não corresponde ao ID do item.");
            }

            var existingItem = await _context.TodoItems.FindAsync(id);

            if (existingItem == null)
            {
                return NotFound("Item não encontrado.");
            }

            // Atualize apenas as propriedades relevantes
            existingItem.Title = updatedItem.Title;
            existingItem.IsComplete = updatedItem.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(Guid id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
