using AutoMapper;
using Eventures.Data.Models;
using Eventures.Data.ViewModels.Events;
using Eventures.Data.ViewModels.Orders;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Eventures.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Event, EventTableModel>()
                 .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)))
                 .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)));

            CreateMap<Order, OrderModel>()
                .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Event.Name))
                .ForMember(dest => dest.OrderedOn, opt => opt.MapFrom(src => src.OrderedOn.ToString("dd-MMM-yyyy H:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Customer.UserName));
        }
    }
}
