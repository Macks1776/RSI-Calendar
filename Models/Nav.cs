namespace RSI_Calendar.Models
{
    public static class Nav
    {
        // If the "path" entered is equal to "currentController/currentAction", give the link a class
        // of "Active". Settings for "Active" class are found in site.css.
        public static string Active(string path, string currentController, string currentAction) => 
            (path == currentController + "/" + currentAction) ? "active" : "";
    }
}
