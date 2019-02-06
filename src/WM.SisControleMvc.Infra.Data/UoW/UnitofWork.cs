using WM.SisControleMvc.Infra.Data.Context;

namespace WM.SisControleMvc.Infra.Data.UoW
{
    public class UnitofWork : IUnitofWork
    {
        private readonly SisControleMvcContext _context;

        public UnitofWork(SisControleMvcContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
