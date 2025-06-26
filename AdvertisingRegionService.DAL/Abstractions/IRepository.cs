namespace AdvertisingRegionService.DAL.Abstractions;

/// <summary>
/// Repository for work with entity of type <typeparam name="T"/>
/// </summary>
/// <typeparam name="T">Type entity that implements <see cref="IEntity"/>.</typeparam>
public interface IRepository<T> where T : IEntity
{
    /// <summary>
    /// Get all entities of type <typeparam name="T"/>
    /// </summary>
    /// <returns>Enumerable <see cref="IEnumerable{T}"/> to select all entities</returns>
    IReadOnlyCollection<T> GetAll();
    /// <summary>
    /// Get entity by Id
    /// </summary>
    /// <param name="id">Unique Id to entity</param>
    /// <returns>Entity of type <typeparamref name="T"/></returns>
    T? GetById(Guid id);
    /// <summary>
    /// Add new entity to repository
    /// </summary>
    /// <param name="entity">Entity to add</param>
    void Add(T entity);
    /// <summary>
    /// Add a collection of entities to repository
    /// </summary>
    /// <param name="entities">Collection of entities to add</param>
    void AddRange(IEnumerable<T> entities);
    /// <summary>
    /// Update exisiting entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    void Update(T entity);
    /// <summary>
    /// Remove entity from repository
    /// </summary>
    /// <param name="entity">Entity to remove</param>
    void Remove(T entity);
}