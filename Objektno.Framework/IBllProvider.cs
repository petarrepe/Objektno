using System.Collections;

namespace Objektno.Framework
{
    public interface IBllProvider
    {
        void Validate(object businessObjet, string propertyName);
        void SaveChanges(IList changes);
        void Save(object busiessObject);
    }
}