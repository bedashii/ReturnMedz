using System.Web;
using ChattersLib.ChattersDBLists;

namespace Chatters
{
    public class CustomSiteMapProvider : StaticSiteMapProvider
    {
        #region Members

        private readonly object _siteMapLock = new object();
        private SiteMapNode _siteMapRoot;

        #endregion

        #region Methods

        public override SiteMapNode BuildSiteMap()
        {
            // Use a lock to provide thread safety
            lock (_siteMapLock)
            {
                if (_siteMapRoot != null)
                {
                    return _siteMapRoot;
                }

                base.Clear();

                CreateSiteMapRoot();
                CreateSiteMapNodes();

                return _siteMapRoot;
            }
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return BuildSiteMap();
        }

        private void CreateSiteMapRoot()
        {
            _siteMapRoot = new SiteMapNode(this, "Home", "~/Main.aspx", "Home", "Home");
            AddNode(_siteMapRoot);
        }

        private void CreateSiteMapNodes()
        {
            MenuList menuList = new MenuList();
            menuList.GetAll();

            AddNode(new SiteMapNode(this, "AboutUs", "~/AboutUs.aspx", "About Us", "About Us"), _siteMapRoot);

            SiteMapNode nodeMenu = new SiteMapNode(this, "Menu", "~/Menu.aspx", "Menu", "Menu");
            menuList.ForEach(subMenu =>
                {
                    SiteMapNode node = new SiteMapNode(this, subMenu.Title, "~/Menu.aspx?Sub=" + subMenu.ID.ToString(), subMenu.Title, subMenu.Title);
                    AddNode(node, nodeMenu);
                });

            AddNode(nodeMenu, _siteMapRoot);
            AddNode(new SiteMapNode(this, "ContactUs", "~/ContactUs.aspx", "Contact Us", "Contact Us"), _siteMapRoot);
        }

        #endregion
    }
}