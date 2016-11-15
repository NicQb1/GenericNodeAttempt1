using Neo4jClient;
using System.Collections.Generic;

namespace Graph_Database_Access.AccessClasses
{
    public interface IGDBAccess<Tout> where Tout : class
    {
        NodeReference<Tout> InsertNode(Tout node);

       

        Tout GetObject(object value);

        bool exciteNode(Tout node, int exitationAmoun);

        bool exciteNode(NodeReference<Tout> nodeRef, int exitationAmoun);

        List<NodeReference> getChildNodes(NodeReference<Tout> nodeRef);


    }
        
        
}
