using DesafioDotNet.DataAccess;
using DesafioDotNet.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Net.Http;
using System.Net;

namespace DesafioDotNet.Controllers
{
    public class ProductController : ApiController
    {

        private readonly Product objproduct = new Product();

        // GET api/v1/product
        [HttpGet]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<ProductModel>))]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent, Type = typeof(string))]
        public IHttpActionResult GetAll()
        {
            IEnumerable<ProductModel> produtos = objproduct.GetAllProduct();
            if (produtos.ToList().Count > 0)
                return Ok(produtos);

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        // GET api/v1/product/5
        [HttpGet]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(ProductModel))]
        [SwaggerResponse(System.Net.HttpStatusCode.NoContent, Type = typeof(string))]
        public IHttpActionResult GetById(int id)
        {
            ProductModel produto = objproduct.GetProductData(id);
            if (produto.Id != null)
                return Ok(produto);

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        //POST api/v1/product
        [HttpPost]
        public IHttpActionResult Post([FromBody] RequestProduct product)
        {
            if (!string.IsNullOrEmpty(product.Brand) && !string.IsNullOrEmpty(product.Name) && double.TryParse(product.Price.ToString(), out _))
            {
                bool retorno = objproduct.AddProduct(product);
                if (retorno)
                    return Ok();

                return BadRequest("Erro ao inserir registro!");
            }
            return BadRequest("Por Favor, verifique os campos e tente novamente!");

        }

        // PUT api/v1/product/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] RequestProduct product, int id)
        {
            if (!string.IsNullOrEmpty(product.Brand) && !string.IsNullOrEmpty(product.Name) && double.TryParse(product.Price.ToString(), out _))
            {
                bool retorno = objproduct.UpdateProduct(product, id);
                if (retorno)
                    return Ok();

                return BadRequest("Erro ao alterar registro!");
            }
            return BadRequest("Por Favor, verifique os campos e tente novamente!");
        }

        // DELETE api/v1/product/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool retorno = objproduct.DeleteProduct(id);
            if(retorno)
                return Ok("Registro deletado com sucesso");

            return BadRequest("Erro ao remover registro!");
        }
    }
}
