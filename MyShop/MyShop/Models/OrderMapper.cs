using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using MyShop.DB.Models;
using System.Collections.Generic;

namespace MyShop.API.Models
{
    public static class OrderMapper
    {
        //это маппер-костыль, переделать не автомаппер не успела:(
        public static OrderWithItems ToDataModel(OrderInputModel model)
        {
            var dataModel = new OrderWithItems()
            {
                OrderItems = new List<Order_Product>()
            };

            foreach (OrderItem item in model.OrderItems)
            {
                var orderProduct = new Order_Product()
                {
                    Product = new Product() { Id = item.ProductId },
                    Value = item.Value
                };
                dataModel.OrderItems.Add(orderProduct);
            }

            dataModel.RepId = model.RepId;
            dataModel.CustomerId = model.CustomerId;
            return dataModel;
        }
        public static OrderWithItemsOutputModel ToOutputModel(OrderWithItems model)
        {
            var outputModel = new OrderWithItemsOutputModel()
            {
                orderItemOutput = new List<OrderItemOutputModel>()
            };

            foreach (Order_Product item in model.OrderItems)
            {
                var orderItemOutput = new OrderItemOutputModel()
                {
                    Brand = item.Product.Brand,
                    Model = item.Product.Model,
                    LocalPrice = item.LocalPrice,
                    Value = item.Value
                };
                outputModel.orderItemOutput.Add(orderItemOutput);
                outputModel.LocalAmount += item.LocalPrice;
            }

            outputModel.RepName = model.RepName;
            outputModel.OrderDate = model.OrderDate.ToString(@"dd.MM.yyyy");
            outputModel.OrderTime = model.OrderDate.ToString(@"T");
            outputModel.ValuteId = model.Valute.Id;
            return outputModel;
        }

        public static List<OrderWithItemsOutputModel> ToOutputModels(List<OrderWithItems> models)
        {
            var outputModels = new List<OrderWithItemsOutputModel>();
            foreach (OrderWithItems model in models)
            {
                var outputModel = new OrderWithItemsOutputModel()
                {
                    orderItemOutput = new List<OrderItemOutputModel>()
                };

                foreach (Order_Product item in model.OrderItems)
                {
                    var orderItemOutput = new OrderItemOutputModel()
                    {
                        Brand = item.Product.Brand,
                        Model = item.Product.Model,
                        LocalPrice = item.LocalPrice,
                        Value = item.Value
                    };
                    outputModel.orderItemOutput.Add(orderItemOutput);
                    outputModel.LocalAmount += item.LocalPrice;
                }

                outputModel.RepName = model.RepName;
                outputModel.OrderDate = model.OrderDate.ToString(@"dd.MM.yyyy");
                outputModel.OrderTime = model.OrderDate.ToString(@"T");
                outputModel.ValuteId = model.Valute.Id;
                outputModels.Add(outputModel);
            }
            return outputModels;
        }
    }

}
