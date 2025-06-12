using AutoMapper;
using ePizzaHub.Core.Contracts;
using ePizzaHub.Models.Response;
using ePizzaHub.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Core.Concrete
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemrepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemrepository,IMapper mapper)
        {
            _itemrepository = itemrepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetItemResponse>> GetItemsasync()
        {
           var item =  _itemrepository.GetAll();
           var response = _mapper.Map<IEnumerable<GetItemResponse>>(item);

            return response;
        }
    }
}
