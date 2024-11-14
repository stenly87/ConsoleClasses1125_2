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
            /*
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
            */
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

            // 14.11.2024
            // классы - могут быть абстрактными (abstract), закрытыми (sealed), статичными (static)
            // интерфейсы не содержат реализацию (в 99% случаев)
            // возможна перегрузка некоторых элементов (методов, свойств) в случаях:
            // в абстрактном классе есть абстрактный элемент 
            // в родительском классе есть элемент, помеченный virtual
            // перегрузка это переопределение действия элемента в 
            // дочернем классе, перегрузка помечается словом override
            // с экземпляром объекта мы можем работать с помощью 
            // шаблона любого из родительских классов или интерфейса

            // наследование классов предпочтительнее в случаях, когда
            // наследники выполняют почти тот же функционал, что родитель, т.е. они только расширяют функционал
            // наследование интерфейсов полезнее в случаях, когда
            // есть необходимость вынести отдельно функционал разных объектов, 
            // которые этот функционал могут выполнять по-разному

            List<Animal> zoo = new List<Animal>();
            zoo.Add(new Wolf()        { Name = "Волк"});
            zoo.Add(new Parrot()      { Name = "Попка"});
            zoo.Add(new Duck()        { Name = "Скрудж"});
            zoo.Add(new Dolphin()     { Name = "Дельфин"});
            zoo.Add(new Nightingale() { Name = "Разбойник"});

            zoo.First().Hunger = 100;

            foreach (Animal animal in zoo)
            {
                if (animal is IWalk walk)
                    walk.Walk();
                if (animal is ISwim swim)
                    swim.Swim();
                animal.Eat();
            }

            var singers = zoo.Where(s => s is ISing).Select(s=>(ISing)s);
            foreach (var singer in singers)
                singer.Sing();

            // базовые принципы ООП:
            // 0) абстрагирование
            // 1) инкапсуляция
            // 2) наследование
            // 3) полиморфизм

            // абстрагирование - это умение отбрасывать лишнее при проектировании
            // инкапсуляция - объединение кода и данных, которое выражается 
            // в скрытии функционала внутри класса. Код, который относится только к объекту класса, должен быть внутри этого класса
            // т.е. состояние экземпляра должно изменяться внутри него, а не другими классами снаружи
            // наследование - возможность расширения классов путем создания новых классов
            // используется аккуратно во избежание принудительного
            // навязывания ненужного функционала наследникам
            // полиморфизм - один интерфейс - множество реализаций
        }
    }

    // будет некий зоопарк с животными, надо кое-что разработать
    // по задумке будут разные животные, пока директор хочет, чтобы был волк и попугай
    // завозим соловья, завозим утку
    // завозим дельфина
    // резиновую утку
    // будет полезнее избавиться от сложной иерархии и перейти на интерфейсы

    interface IWalk
    {
        void Walk()
        {
            Console.WriteLine("Ходьба");
        }
    }

    interface ISwim
    {
        void Swim();
    }
    interface IFly
    {
        void Fly();
    }
    interface ISing
    {
        void Sing();
    }

    abstract class Animal
    {
        public double Hunger { get; set; }
        protected abstract string Food { get; }
        public string Name { get; set; }
        public void Eat()
        {
            Console.WriteLine($"{Name} кушает {Food}");
        }
    }

    class Wolf : Animal, IWalk, ISwim
    {
        protected override string Food => "мясо";

        public void Swim()
        {
            Console.WriteLine("Волк плавает в миске с водой");
        }

        public void Walk()
        {
            Console.WriteLine("Волк бегает на 4 лапах по кругу");
        }
    }
    class Dolphin : Animal, ISwim
    {
        protected override string Food => "рыбу";

        public void Swim()
        {
            Console.WriteLine("Дельфин плавает");
        }
    }
    class Parrot : Animal, IFly, IWalk, ISing
    {
        protected override string Food => "просо";

        public void Fly()
        {
            Console.WriteLine("Попуг летает");
        }

        public void Sing()
        {
            Console.WriteLine("Попуг дурак");
        }

        public void Walk()
        {
            Console.WriteLine("Попугай смешно прыгает на двух лапках");
        }
    }

    class Nightingale : Animal, IFly, IWalk, ISing
    {
        protected override string Food => "семки";

        public void Fly()
        {
            Console.WriteLine("Соловей летает");
        }

        public void Sing()
        {
            Console.WriteLine("Соловей: пу-пу-пу");
        }

        public void Walk()
        {
            Console.WriteLine("Соловей несмешно прыгает на двух лапках");
        }
    }

    class Duck : Animal, IFly, IWalk, ISwim
    {
        protected override string Food => "червяков";

        public void Fly()
        {
            Console.WriteLine("Утка летает");
        }

        public void Swim()
        {
            Console.WriteLine("Утка плавает");
        }

        public void Walk()
        {
            Console.WriteLine("Утка смешно переваливается на двух лапках");
        }
    }


    /*
    abstract class Animal
    {
       
    }

    abstract class SwimAnimal : Animal
    {
        public abstract void Swim();
    }

    abstract class GroundAnimal : Animal
    {
        public abstract void Walk();
    }

    abstract class Bird : GroundAnimal
    {
        public abstract void Fly();
    }

    class Wolf : GroundAnimal
    {
        public override void Walk()
        {
            Console.WriteLine("Волк бегает на 4 лапах по кругу");
        }
    }

    class Dolphin : SwimAnimal
    {
        public override void Swim()
        {
            Console.WriteLine("Дельфин плавает");
        }

    }

    class Parrot : Bird
    {
        public override void Walk()
        {
            Console.WriteLine("Попугай смешно прыгает на двух лапках");
        }

        public override void Fly()
        { 
            Console.WriteLine("Попуг летает");
        }
    }

    class Соловей : Bird
    {
        public override void Walk()
        {
            Console.WriteLine("Соловей несмешно прыгает на двух лапках");
        }

        public override void Fly()
        {
            Console.WriteLine("Соловей летает");
        }

        public void Sing()
        {
            Console.WriteLine("Соловей поет");
        }
    }

    class Duck : Bird
    {
        public override void Walk()
        {
            Console.WriteLine("Утка смешно прыгает на двух лапках");
        }

        public override void Fly()
        {
            Console.WriteLine("Утка летает");
        }

        public void Swim()
        {
            Console.WriteLine("Утка плавает");
        }
    }*/


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
        public Student(string key) : base(key)
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
