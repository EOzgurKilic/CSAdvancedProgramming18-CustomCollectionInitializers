namespace CSAdvancedProgramming18_CustomCollectionInitializers;
using System.Collections;
class Program
{
    static void Main(string[] args)
    {
        //Collection Initializers
        //is a feature C# language brings along with itself which is used in order to make collection creations easier and more readable
        List<string> list1 = new List<string>() {"a","b","c","d" }; //The curly brackets is the collection initializer pattern
                                                                    //(Should not be confused with object initializers, becuase objects initializers allow us to..
                                                                    //.. give values to the properties of the class).
        //Now here is the question coming;
        //How can we add this feature to our own classes and want our initializer in the instance declaration of our classes to act as collection initializer..
        //.. rather than object initializer?
        
        //First condition: The class must show a collection class behaviour implementing IEnumerable interface.
        //Second condition: The relevant class must implement the Add() function.
        //Check the class CustomCollectionClass1 declared below.
        //Now lets instanciate the class we prepared
        CustomCollectionClass1 collection1 = new CustomCollectionClass1(){"First element","Second element", "Third element"};
        foreach (var VARIABLE in collection1)
            Console.WriteLine(VARIABLE);
        //Now lets try declaring an instance utilizing from the overloading of the Add() method;
        CustomCollectionClass1 collection2 = new CustomCollectionClass1() {
            {"Efe","Name"},
            {"Ozgur","Middle Name"},
            {"Kilic","Surname"}
        };
            for (int i = 0; i < collection2.Count(); i++)
            {
                Console.WriteLine($"{collection2[i]} is the {collection2.listElementDescription[i]} of the person.");
            }
            collection2[1] = "Surname";
        
    }
}

class CustomCollectionClass1 : IEnumerable<string>
{
    List<string> _list1 = new List<string>();
    List<string> _listElementDescription = new List<string>();
    
    //Setting indexer to our collectionclass because the implemented interface does not bring this feature automatically
    public string/*should be the same type value keyword is in*/ this[int index]
    {
        get { return _list1[index]; }
        set { _list1[index] = value; }
    }

    public List<string> listElementDescription {
        get { return _listElementDescription;}
        set { _listElementDescription = value; }
    }
    public IEnumerator<string> GetEnumerator()
    {
        return _list1.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list1.GetEnumerator();
    }

    public void Add(string item) //This parameter is the type that must match the variables' type given in the collection initializer in the declaration.
    //This method is overloadable and we can take tuple values from collection initializer even though we still add only the string value to our list.
    {
        _list1.Add(item);
    }

    public void Add(string item, string description)
    {
        _list1.Add(item); //We added the item and we will be taking the second parameter as a description to the element given along.
        listElementDescription.Add(description);
    }
}