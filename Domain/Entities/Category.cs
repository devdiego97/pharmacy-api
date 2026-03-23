

namespace Domain.Entities
{
    public class Category : BaseEntity
    {

		public Guid IdPharmacy{get; private set;}=Guid.NewGuid();
		public Pharmacy Pharmacy{get;private set;}
        public string Name{get;private set;}=string.Empty;
		public string? Description{get;private set;}=string.Empty;

		public ICollection<Medication> Medicaments{get; private set;} = new List<Medication>();
		protected Category(){}
		public Category(Guid idPharmacy,string name,string description) : base()
			{
				
				this.IdPharmacy=idPharmacy;
				this.Name=name;
				this.Description=description;
			}

    }
}