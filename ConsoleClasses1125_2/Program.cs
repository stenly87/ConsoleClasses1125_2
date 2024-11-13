namespace ConsoleClasses1125_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Наследование - возможность расширения класса 
            // с помощью добавление новых классов
            // наследование производится с помощью указания
            // класса-родителя через двоеточие после имени класса-наследника
            // наследуются все элементы класса кроме помеченных модификатором private
            // 

            Student student = new Student("somekey");
            student.Name = "Test";
            student.Surname = "Testing";
            student.Birthday = DateTime.UtcNow;
            student.Print();
            student.Speak("Я студент");
            student.SpeakStudent();

            Human human = student;
            human.Speak("Запрос через другую ссылку");

            IHuman iHuman = student;
            int age = iHuman.GetAge();
            Console.WriteLine(age);

            IMonkey monkey = student;
            monkey.SpeakMonkey();

            // в случае, если в родительском классе определен конструктор, то класс-наследник должен также 
            // определять свой конструктор, в котором будет вызывать один из конструкторов родительского класса

            // экземпляр класса-наследника можно в любой момент
            // преобразовать к типу класса-родителя
            // расширение базового класса до класса-наследника
            // запрещено и будет выдавать ошибку во время исполнения
            /*
            Human human2 = new Human("asdas");
            Student student1 = (Student)human2;
            */
            // в с# один класс может наследовать только один другой класс
            // зато один класс может наследовать множество интерфейсов
            // интерфейс это ссылочный тип данных, который не имеет состояния и не имеет реализации для своих элементов
            // интерфейс содержит свойства, события, методы, при этом у них 
            // как правило нет реализации. Классы реализуют интерфейсы, предоставляю
            // тело для всех элементов наследуемых интерфейсов. С 8 версии языка интерфейс тоже может содержать реализацию
            // интерфейсы создаются с буквой I в имени, указывающей на то, что этот тип - интерфейс
            // все элементы, описанные в интерфейсе являются публичными, модификатор области видимости к ним не указывается
            // интерфейсы в наследовании указываются через запятую, если 
            // есть класс-родитель, но он указывается первым, следом - интерфейсы
            // интерфейсы не могут быть созданы сами по себе
            // интерфейсы можно использовать только с помощью экземляров классов, реализующих данные интерфейсы

            // Ключевое слово abstract запрещает классу иметь экземпляры
            // Абстрактный класс, как интерфейс, может не иметь реализации для 
            // свойств, методов и тп.
            // В этом случае методы тоже помечаются слово abstract, а классы-наследники
            // должны предложить реализацию всех абстрактных элементов базового класса 
            // Ключевое слово sealed запрещает классу иметь наследников

            // 
        }
    }

    interface IMonkey
    {
        void SpeakMonkey();
    }

    interface IHuman : IMonkey
    {
        int GetAge();
    }

    public abstract class Human
    {
        public Human(string key)
        {
            keyHouse = key;
        }

        private string keyHouse;

        public virtual string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        internal abstract void Think();

        internal void Print()
        {
            Think();
            Console.WriteLine($"{Name} {Surname} {Birthday} {keyHouse}");
        }

        protected void SpeakText(string text)
        {
            Console.WriteLine($"{Name}: {text}");
        }

        public void Speak(string text)
        {
            SpeakText(text);
        }
    }
    // студент наследует класс Human
    public class Student : Human, IHuman
    {
        public Student(string key): base(key)
        {
            
        }

        public override string Name 
        { 
            get => base.Name;
            set => base.Name = value;
        }

        public int GetAge()
        {
            return 10;
        }

        public void SpeakMonkey()
        {
            SpeakText("у-у-у-у");
        }

        public void SpeakStudent()
        {
            SpeakText("ы");
        }

        internal override void Think()
        {
            Console.WriteLine($"{Name} думает");
        }
    }
}
