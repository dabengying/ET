using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;
using Module.Login;

namespace Editor
{
	public partial class Bootstrapper : MefBootstrapper
	{
		protected override void ConfigureAggregateCatalog()
		{
			this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
			this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(LoginModule).Assembly));
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();
		}

		protected override void InitializeShell()
		{
			base.InitializeShell();
			Application.Current.MainWindow = (Shell)this.Shell;
			Application.Current.MainWindow.Show();
		}

		protected override DependencyObject CreateShell()
		{
			return this.Container.GetExportedValue<Shell>();
		}
	}
}