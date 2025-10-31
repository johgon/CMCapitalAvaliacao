using CMCapitalAvaliacao.Data;
using CMCapitalAvaliacao.Repositories.Interfaces;
using CMCapitalTesteController.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CMCapitalAvaliacao.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Retorno<IEnumerable<T>> GetAll()
        {
            Retorno<IEnumerable<T>> ret = new Retorno<IEnumerable<T>>();
            try
            {
                ret.Value = _dbSet.ToList();
                ret.sucesso = true;
                ret.mensagem = "";
            }
            catch (System.Exception mensagem)
            {
                ret.Value = null;
                ret.sucesso = false;
                ret.mensagem = "Não foi possível fazer a busca de por motivos de " + mensagem;
            }
            return ret;
        }

        public Retorno<T?> GetById(int id)
        {
            Retorno<T?> ret = new Retorno<T?>();
            try
            {
                ret.Value = _dbSet.Find(id); ;
                ret.sucesso = true;
                ret.mensagem = "";
            }
            catch (System.Exception mensagem)
            {
                ret.Value = null;
                ret.sucesso = false;
                ret.mensagem = "Não foi possível fazer a busca de por motivos de " + mensagem;
            }
            return ret;
        }

        public Retorno<T> AddOrUpdate(T entity, int? id)
        {
            Retorno<T> ret = new Retorno<T>();
            if (id != null && GetById(id.Value) != null)
            {
                try
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                    ret.Value = entity;
                    ret.sucesso = true;
                    ret.mensagem = "";
                }
                catch (System.Exception mensagem)
                {
                    ret.Value = null;
                    ret.sucesso = false;
                    ret.mensagem = "Não foi possível atualizar o item por " + mensagem;
                }

                return ret;
            }
            else
            {
                try
                {
                    _dbSet.Add(entity);
                    _context.SaveChanges();
                    ret.Value = entity;
                    ret.sucesso = true;
                    ret.mensagem = "";
                }
                catch (System.Exception mensagem)
                {
                    ret.Value = null;
                    ret.sucesso = false;
                    ret.mensagem = "Não foi possível adicionar o item por " + mensagem;
                }
                return ret;
            }

        }
        public Retorno<bool> Delete(int id)
        {
            Retorno<bool> ret = new Retorno<bool>();
            var entity = GetById(id);
            if (entity != null)
            {
                try
                {
                    _dbSet.Remove(entity.Value);
                    _context.SaveChanges();
                    ret.Value = true;
                    ret.sucesso = true;
                    ret.mensagem = "";
                }
                catch (System.Exception mensagem)
                {
                    ret.Value = false;
                    ret.sucesso = false;
                    ret.mensagem = "Não foi possível remover o item por " + mensagem;
                }
            }
            return ret;
        }
    }
}
