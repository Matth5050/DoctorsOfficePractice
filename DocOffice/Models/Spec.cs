using System.Collections.Generic;

namespace DocOffice.Models
{
  public class Spec
  {
    public Spec()
    {
      this.JoinEntities = new HashSet<SpecDoctor>();
    }

    public int SpecId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<SpecDoctor> JoinEntities { get; set; }
  }
}