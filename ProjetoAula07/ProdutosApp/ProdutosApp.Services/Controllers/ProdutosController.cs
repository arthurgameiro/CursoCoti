using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Repositories;
using ProdutosApp.Services.Models;

namespace ProdutosApp.Services.Controllers
{
    [Route("api/[controller]")] //ENDPOINT: /api/produtos
    [ApiController] //controlador de API
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutosPostRequestModel model)
        {
            try
            {
                //Criando um objeto Produto (entidade)
                var produto = new Produto()
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Preco = model.Preco,
                    Quantidade = model.Quantidade,
                    CategoriaId = model.CategoriaId,
                    FornecedorId = model.FornecedorId
                };

                //gravar o produto no banco de dados
                var produtoRepository = new ProdutoRepository();
                produtoRepository.Inserir(produto);

                //retornar sucesso HTTP 201 (CREATED)
                return StatusCode(201, new
                {
                    Message = "Produto cadastrado com sucesso",
                    produto.Id
                });
            }
            catch (Exception e)
            {
                //Erro do servidor (INTERNAL SERVER ERROR) HTTP 500
                return StatusCode(500, new { e.Message });
            }
        }



        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetResponseModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                //consultando os produtos no banco de dados
                var produtoRepository = new ProdutoRepository();
                var produtos = produtoRepository.ObterTodos();

                var response = new List<ProdutosGetResponseModel>();
                foreach (var item in produtos)
                {
                    response.Add(new ProdutosGetResponseModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Preco = item.Preco,
                        Quantidade = item.Quantidade,
                        Categoria = new CategoriasGetResponseModel
                        {
                            Id = item.Categoria?.Id,
                            Nome = item.Categoria?.Nome
                        },
                        Fornecedor = new FornecedoresGetResponseModel
                        {
                            Id = item.Fornecedor?.Id,
                            RazaoSocial = item.Fornecedor?.RazaoSocial,
                            Cnpj = item.Fornecedor?.Cnpj
                        }
                    });
                }
                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR -> HTTP 500
                return StatusCode(500, new { e.Message });
            }
        }
    }
}