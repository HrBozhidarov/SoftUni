using AutoMapper;
using CarDealer.Dtos.Import;
using CarDealer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImportDto, Supplier>();
            CreateMap<PartsImportDto, Part>();
            CreateMap<CarImportDto, Car>();
            CreateMap<CustomerImportDto, Customer>();
        }
    }
}
