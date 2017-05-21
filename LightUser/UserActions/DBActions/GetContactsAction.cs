namespace LightUser.UserActions.DBActions
{
    public sealed class GetContactsAction : IAction
    {
        public string Filter = string.Empty;
        public string FilterValue = string.Empty;
        public string Tag = "DBTag";
        public GetContactsAction()
        {
            Action = "DBGetContactsAction";
        }

        public GetContactsAction(string filter, string filterValue)
        {
            Action = "DBGetContactsAction";
            Filter = filter;
            FilterValue = filterValue;
        }
    }
}
