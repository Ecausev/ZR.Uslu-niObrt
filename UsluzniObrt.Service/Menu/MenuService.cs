using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;
using UsluzniObrt.Repository;

namespace UsluzniObrt.Service
{

    public class MenuService : IMenuService
    {
        public IMenuitemRepository _menuitemRepository;
        
        public MenuService()
        {


        }
        public MenuService(IMenuitemRepository menuitemRepository)
        {
            _menuitemRepository = menuitemRepository;
        }
        public void Add(MenuItem newItem)
        {
            _menuitemRepository.Insert(newItem);
            _menuitemRepository.Save();
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void edit(MenuItem item)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetAll()
        {
            return _menuitemRepository.GetAll().ToList();
        }

        public MenuItem GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
