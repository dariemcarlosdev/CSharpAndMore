namespace ABSTRACT_MEMBERS
{

    /*
    Static and Non-Static Members

    Static members: Members of a class that do not require a instance for initialization.
    Non-Static members: Members of a class which require an instance of a class for both initialization and execution. 

    whenever we declare variables using static modifier or when er declare a variable inside static block then those variables are static.
    Static variables hold the application level data which is going to be the same for all the objects.

    int x=100; //non static
    static int x = 5; //static
    static void Main()
    {
        int z =10; //static
    }

    Static variable gets initialized immediately once the class starts, whereas non-static variables are initialized only after creating the object.
    Static variables gets initialized only once during the life cycle of a class, non-static one get initialized 0 or n times, depending on # objects created.

    To access static members class name is needed, non-static members a instance of class is needed.

    */
    
    public class StaticMembersExamples
    {
        public int x;
        public static int y = 20;
        public StaticMembersExamples(int x)
        {
            this.x = x;
        }
    }
}