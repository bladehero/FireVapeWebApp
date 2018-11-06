using DAL.DAO;

namespace DAL
{
    public class UnitOfWork
    {
        private string connectionString;

        public UnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;
        }


        private ClientDao clients;
        private ComponentTypeDao componentTypes;
        private LineageDao lineages;
        private LiquidDao liquids;
        private LiquidVolumePriceDao liquidVolumePrices;
        private ProducerDao producers;
        private ProductDao products;
        private RoleDao roles;
        private ComponentDao components;
        private LiquidComponentDao liquidComponents;


        public RoleDao Roles
        {
            get
            {
                if (roles == null)
                    roles = new RoleDao(connectionString);
                return roles;
            }
        }
        public ClientDao Clients
        {
            get
            {
                if (clients == null)
                    clients = new ClientDao(connectionString);
                return clients;
            }
        }
        public ComponentTypeDao ComponentTypes
        {
            get
            {
                if (componentTypes == null)
                    componentTypes = new ComponentTypeDao(connectionString);
                return componentTypes;
            }
        }
        public LineageDao Lineages
        {
            get
            {
                if (lineages == null)
                    lineages = new LineageDao(connectionString);
                return lineages;
            }
        }
        public LiquidDao Liquids
        {
            get
            {
                if (liquids == null)
                    liquids = new LiquidDao(connectionString);
                return liquids;
            }
        }
        public LiquidVolumePriceDao LiquidVolumePrices
        {
            get
            {
                if (liquidVolumePrices == null)
                    liquidVolumePrices = new LiquidVolumePriceDao(connectionString);
                return liquidVolumePrices;
            }
        }
        public ProducerDao Producers
        {
            get
            {
                if (producers == null)
                    producers = new ProducerDao(connectionString);
                return producers;
            }
        }
        public ProductDao Products
        {
            get
            {
                if (products == null)
                    products = new ProductDao(connectionString);
                return products;
            }
        }
        public ComponentDao Components
        {
            get
            {
                if (components == null)
                    components = new ComponentDao(connectionString);
                return components;
            }
        }
        public LiquidComponentDao LiquidComponents
        {
            get
            {
                if (liquidComponents == null)
                    liquidComponents = new LiquidComponentDao(connectionString);
                return liquidComponents;
            }
        }
    }
}
