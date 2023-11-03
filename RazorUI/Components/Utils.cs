using System.Text.RegularExpressions;

namespace Daemon.RazorUI.Components;

public class Utils {

public static string GetClass(params string[] classNames) {
    string classString = string.Join(" ", classNames);
    string cleanClasses = Regex.Replace(classString, @"\s+", " ");
    string[] uniqueClasses = cleanClasses.Split(" "); 
    // We will filter out duplicates
    // each element of uniqueClasses will be split by "-" character
    // matches will be prioritized by taking the last match in the array
    // two elements match if their last element is different, but the others are the same
    // e.g. "bg-red-500" and "bg-red-600" match, but "bg-red-500" and "bg-blue-500" don't
    var filteredClasses = new List<string>();
    foreach (var className in uniqueClasses) {
        var parts = className.Split("-");
        var matchFound = false;
        for (int i = filteredClasses.Count - 1; i >= 0; i--) {
            var filteredParts = filteredClasses[i].Split("-");
            if (parts.Length == filteredParts.Length && parts.Take(parts.Length - 1).SequenceEqual(filteredParts.Take(parts.Length - 1))) {
                matchFound = true;
                break;
            }
        }
        if (!matchFound) {
            filteredClasses.Add(className);
        }
    }
        string result = string.Join(" ", filteredClasses);
        return result;
        }
}