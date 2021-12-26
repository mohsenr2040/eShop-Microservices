﻿using MediatR;
using ProductApi.Data.Repository;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProductApi.Messaging.Send.Sender;

namespace ProductApi.Service.Command
{
    public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand,Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IupdateproductSender _updateproductSender;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(UpdateProductCommand request,CancellationToken cancellationtoken)
        {
            return await _productRepository.UpdateAsync(request.Product);
        }
    }
}
