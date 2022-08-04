namespace DocOffice.Models
{
  public class SpecDoctor
  {
    public int SpecDoctorId { get; set; }
    public int DoctorId { get; set; }
    public int SpecId { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual Spec Spec { get; set; }
  }
}