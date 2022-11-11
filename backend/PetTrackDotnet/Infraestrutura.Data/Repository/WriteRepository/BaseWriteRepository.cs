﻿using Infraestrutura.DataBaseContext;
using Infraestrutura.Repository.Interface.Base;

namespace Infraestrutura.Repository.WriteRepository;

public class BaseWriteRepository <T> : IBaseWriteRepository<T> where T : class
{
    private Context _context;

    public BaseWriteRepository(Context context)
    {
        _context = context;
    }
    
    public void Add(T entidade)
    {
        _context.Set<T>().Add(entidade);
        _context.SaveChanges();
    }

    public void AddRange(List<T> lEntidade)
    {
        _context.AddRange(lEntidade);
        _context.SaveChanges();
    }

    public void Update(T entidade)
    {
        _context.Set<T>().Update(entidade);
        _context.SaveChanges();
    }
    
    public void UpdateRange(List<T> lEntidade)
    {
        _context.UpdateRange(lEntidade);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var entidade = _context.Set<T>().Find(id);
        if (entidade != null)
            _context.Set<T>().Remove(entidade);
       
        _context.SaveChanges();
    }

    public void DeleteRange(List<T> lEntidade)
    {
        _context.Remove(lEntidade);
        _context.SaveChanges();
    }
    
    public void Dispose() {}
}