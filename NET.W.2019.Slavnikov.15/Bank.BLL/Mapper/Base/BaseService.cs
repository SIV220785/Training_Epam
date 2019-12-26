using System;
using AutoMapper;

namespace Bank.BLL.Mapper.Base
{
    public class BaseService
    {
        private MapperConfiguration mapperConfiguration;

        public IMapper MapperInstance => this.mapperConfiguration?.CreateMapper();

        protected virtual Action<IMapperConfigurationExpression> MapperCustomConfiguration { get; set; } = cfg => { };

        public BaseService()
        {
            this.MapperInitialize();
        }

        private void MapperInitialize()
        {
            this.mapperConfiguration = new MapperConfiguration(MapperCustomConfiguration);
        }
    }
}
