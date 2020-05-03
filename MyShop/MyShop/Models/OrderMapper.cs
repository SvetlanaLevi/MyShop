using MyShop.API.ModelsInput;
using MyShop.API.ModelsOutput;
using MyShop.DB.Models;
using System.Collections.Generic;

namespace MyShop.API.Models
{
    public static class OrderMapper
    {
        //это маппер-костыль, переделать не автомаппер не успела:(
        public static Order ToDataModel(OrderInputModel model)
        {
            var dataModel = new Order()
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
        public static OrderOutputModel ToOutputModel(Order model)
        {
            var outputModel = new OrderOutputModel()
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
            outputModel.Id = (int)model.Id;
            outputModel.RepName = model.RepName;
            outputModel.OrderDate = model.OrderDate.ToString(@"dd.MM.yyyy");
            outputModel.OrderTime = model.OrderDate.ToString(@"T");
            outputModel.ValuteId = model.Valute.Id;
            return outputModel;
        }

        public static List<OrderOutputModel> ToOutputModels(List<Order> models)
        {
            var outputModels = new List<OrderOutputModel>();
            foreach (Order model in models)
            {
                var outputModel = ToOutputModel(model);
                outputModels.Add(outputModel);
            }
            return outputModels;
        }
    }

}
