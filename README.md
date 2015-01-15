# EasyUI.Mvc
EasyUI for ASP.NET Mvc

#### DataGrid
@Html.EasyUI().DataGrid().Name("datagrid");

#### TextBox
@Html.EasyUI().TextBox().Name("textbox");

#### ComboBox
@Html.EasyUI().ComboBox().Name("combobox");

#### LinkButton
@Html.EasyUI().LinkButton().Name("linkbutton");

### Configuration

1. Open Views/Web.config.
2. Locate the namespaces tag.
3. Append an add tag to the namespaces tag.
```
<add namespace="EasyUI.Mvc.UI" />
```
