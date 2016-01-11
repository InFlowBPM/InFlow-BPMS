@using $rootnamespace$.Helpers
@model List<$rootnamespace$.Controllers.TreeViewLocation>

<h2>TreeView</h2>


@(Html.TreeView(Model)
    .EmptyContent("No locations have been defined yet!")
    .Children(m => m.ChildLocations)
    .HtmlAttributes(new { id = "tree" })
    .ChildrenHtmlAttributes(new { @class = "subItem" })
    .ItemText(m => m.Name)
    .ItemTemplate(
        @<text>
            <a href="#@item.Id">@item.Name</a>
        </text>)
)

