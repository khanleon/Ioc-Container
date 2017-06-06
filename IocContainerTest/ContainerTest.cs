using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using IocContainer.Attributes;
using IocContainer.Core;



namespace IocContainerTest
{
#region Test Interfaces
	interface ITest1
	{
		string Name();
	}

	interface ITest2
	{
		int Hash();
	}



	interface One
	{
		string FunctionOne();
		string FunctionTwo();
		
	}
#endregion


#region Test Classes


	class ClassTest1 : ITest1
	{
		public string Name()
		{
			return this.GetType().Name;

		}
	}

	class ClassTest2 : ITest2
	{
		public int Hash()
		{
			return this.GetHashCode();

		}
	}


	class ClassOne : One
	{
		ITest1 m_Itest1 = null;

		[Dependency]
		public ClassOne(ITest1 test1)
		{
			m_Itest1 = test1;
		}

		public string FunctionOne()
		{
			
			return this.GetType().Name;
			
		}

		public string FunctionTwo()
		{
			return m_Itest1.Name();
			

		}

		
	}
#endregion
	
    public class ContainerTest
    {


		[Fact]

		public void InstanceTypeResigtration()
		{
			IContainer container = new IocContainer.Container();

			// testing instance type resigtration for class			
			container.RegisterInstanceType<ITest1, ClassTest1>();

			ITest1 obj1 = container.Resolve<ITest1>();
			Assert.Equal("ClassTest1", obj1.Name());

		}

		[Fact]

		public void InstanceTypeLifeCycle()
		{
			IContainer container = new IocContainer.Container();

			// testing instance type resigtration for class			
			container.RegisterInstanceType<ITest2, ClassTest2>();

			ITest2 obj1 = container.Resolve<ITest2>();

			container.RegisterInstanceType<ITest2, ClassTest2>();
			ITest2 obj2 = container.Resolve<ITest2>();

			Assert.NotEqual(obj2.Hash(), obj1.Hash());

		}



		[Fact]

		public void SingletonRegistration()
		{
			IContainer container = new IocContainer.Container();
			container.RegisterSingletonType<ITest1, ClassTest1>();

			ITest1 obj1 = container.Resolve<ITest1>();
			Assert.Equal("ClassTest1", obj1.Name());
			

		}

		[Fact]
		public void SingletonLifeCycle()
		{
			IContainer container = new IocContainer.Container();
			container.RegisterSingletonType<ITest2, ClassTest2>();

			ITest2 obj1 = container.Resolve<ITest2>();

			container.RegisterSingletonType<ITest2, ClassTest2>();

			ITest2 obj2 = container.Resolve<ITest2>();
			Assert.Equal(obj2.Hash(), obj1.Hash());


		}

		[Fact]

		public void NestedDependency()
		{
			IContainer container = new IocContainer.Container();

			container.RegisterInstanceType<ITest1, ClassTest1>();

			ITest1 obj2 = container.Resolve<ITest1>();

			container.RegisterInstanceType<One, ClassOne>();
			One obj1 = container.Resolve<One>();
			Assert.Equal("ClassOne", obj1.FunctionOne());
			Assert.Equal("ClassTest1", obj1.FunctionTwo());


		}

	

    }
}
