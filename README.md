Our.Umbraco.Tables
=====================

An Umbraco 8+ property editor for generating tabular data in the CMS.
It is created as a data type and then used as a property of a doctype. There is a PropertyValueConverter that will convert the stored data to a strongly typed set of objects when used with ModelsBuilder.

### Install ###

`PM> Install-Package Our.Umbraco.Tables`

**Umbraco Package:** http://our.umbraco.org/projects/developer-tools/Our.Umbraco.Tables

**NuGet Package:** https://www.nuget.org/packages/Our.Umbraco.Tables

### Use ###

After installation, Umbraco should automatically find **Our.Umbraco.Tables** and make it available to you when creating a new data type.

Create a new data type in 'Settings / Data Types' and choose 'Our.Umbraco.Tables' from the drop down.

This is now ready to use on a Document Type.

![Property Editor](https://raw.githubusercontent.com/RY-Digital/Our.Umbraco.Tables/develop/assets/property-editor.png)

### Output ###

If using ModelsBuilder the property should appear as a class
`Our.Umbraco.Tables.Models.TableData`

This contains all the rows, columns, cells and settings. You are free to output this how you see fit. There is a demo site with razor markup to generate a table using Bootstrap classes.

#### Razor ####
You can generate a table with something like this

    @using Our.Umbraco.Tables.Enums
    @using Our.Umbraco.Tables.Models
    @model Our.Umbraco.Tables.Models.TableData

    @{
        var firstRow = Model.Cells.FirstOrDefault();
        var rows = Model.Rows.ToList();
        var columns = Model.Columns.ToList();
        var tableStyles = Model.Settings;
    }

    @if (firstRow != null)
    {
        <table class="@GetCssClass(tableStyles)">
            <thead>
                <tr class="@GetCssClass(tableStyles, Model.Rows.FirstOrDefault())">
                    @foreach (var cell in firstRow)
                    {
                        <th class="@GetCssClass(tableStyles, columns[cell.ColumnIndex])" scope="col">
                            @Html.Raw(cell.Value)
                        </th>
                    }
                </tr>
            </thead>
            <tbody>
                @foreach (var row in Model.Cells.Skip(1))
                {
                    <tr class="@GetCssClass(tableStyles, rows[row.FirstOrDefault().RowIndex])">
                        @foreach (var cell in row)
                        {
                            <td class="@GetCssClass(tableStyles, columns[cell.ColumnIndex])">
                                @Html.Raw(cell.Value)
                            </td>
                        }
                    </tr>
                }
            </tbody>
        </table>
    }

    @functions
    {
        public string GetCssClass(StyleData tableStyles, StyleData styleData = null)
        {
            var styles = tableStyles.BackgroundColor != BackgroundColour.None
                            ? tableStyles.BackgroundColor
                            : styleData?.BackgroundColor ?? BackgroundColour.None;

            switch (styles)
            {
                case BackgroundColour.OddEven:
                    return "is-odd-even";
                case BackgroundColour.OddEvenReverse:
                    return "is-odd-even-reversed";
                case BackgroundColour.Primary:
                    return "is-primary";
                case BackgroundColour.Secondary:
                    return "is-secondary";
                case BackgroundColour.Tertiary:
                    return "is-tertiary";
                default:
                    return null;
            }
        }
    }

![Output](https://raw.githubusercontent.com/RY-Digital/Our.Umbraco.Tables/develop/assets/output.png)

#### JSON ####

If you want JSON then it will output as something like this.

    {
        "settings": {
            "backgroundColor": "None"
        },
        "rows": [
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            }
        ],
        "columns": [
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            },
            {
            "backgroundColor": "None"
            }
        ],
        "cells": [
            [
            {
                "rowIndex": 0,
                "columnIndex": 0,
                "value": "<p><strong>Assets</strong></p>"
            },
            {
                "rowIndex": 0,
                "columnIndex": 1,
                "value": "<p><strong>4 April 2019</strong><br /><strong>£m</strong></p>"
            },
            {
                "rowIndex": 0,
                "columnIndex": 2,
                "value": "<p>%</p>"
            },
            {
                "rowIndex": 0,
                "columnIndex": 3,
                "value": "<p>5 April 2018<br />(note i)<br />£m</p>"
            },
            {
                "rowIndex": 0,
                "columnIndex": 4,
                "value": "<p>%</p>"
            },
            {
                "rowIndex": 0,
                "columnIndex": 5,
                "value": "<p>4 April<br />£m</p>"
            },
            {
                "rowIndex": 0,
                "columnIndex": 6,
                "value": "<p>%</p>"
            }
            ],
            [
            {
                "rowIndex": 1,
                "columnIndex": 0,
                "value": "<p>Residential mortgages (note ii)</p>"
            },
            {
                "rowIndex": 1,
                "columnIndex": 1,
                "value": "<p>180,008</p>"
            },
            {
                "rowIndex": 1,
                "columnIndex": 2,
                "value": "<p>97</p>"
            },
            {
                "rowIndex": 1,
                "columnIndex": 3,
                "value": "<p>144,339</p>"
            },
            {
                "rowIndex": 1,
                "columnIndex": 4,
                "value": "<p>94</p>"
            },
            {
                "rowIndex": 1,
                "columnIndex": 5,
                "value": "<p>145,669</p>"
            },
            {
                "rowIndex": 1,
                "columnIndex": 6,
                "value": "<p>83</p>"
            }
            ],
            [
            {
                "rowIndex": 2,
                "columnIndex": 0,
                "value": "<p>Commercial and other lending (note iii)</p>"
            },
            {
                "rowIndex": 2,
                "columnIndex": 1,
                "value": "<p>9,534</p>"
            },
            {
                "rowIndex": 2,
                "columnIndex": 2,
                "value": "<p>2</p>"
            },
            {
                "rowIndex": 2,
                "columnIndex": 3,
                "value": "<p>11,345</p>"
            },
            {
                "rowIndex": 2,
                "columnIndex": 4,
                "value": "<p>5</p>"
            },
            {
                "rowIndex": 2,
                "columnIndex": 5,
                "value": "<p>11,234</p>"
            },
            {
                "rowIndex": 2,
                "columnIndex": 6,
                "value": "<p>9</p>"
            }
            ],
            [
            {
                "rowIndex": 3,
                "columnIndex": 0,
                "value": "<p>Consumer banking</p>"
            },
            {
                "rowIndex": 3,
                "columnIndex": 1,
                "value": "<p>3,244</p>"
            },
            {
                "rowIndex": 3,
                "columnIndex": 2,
                "value": "<p>1</p>"
            },
            {
                "rowIndex": 3,
                "columnIndex": 3,
                "value": "<p>4,569</p>"
            },
            {
                "rowIndex": 3,
                "columnIndex": 4,
                "value": "<p>1</p>"
            },
            {
                "rowIndex": 3,
                "columnIndex": 5,
                "value": "<p>4,159</p>"
            },
            {
                "rowIndex": 3,
                "columnIndex": 6,
                "value": "<p>8</p>"
            }
            ],
            [
            {
                "rowIndex": 4,
                "columnIndex": 0,
                "value": ""
            },
            {
                "rowIndex": 4,
                "columnIndex": 1,
                "value": "<p>192,786</p>"
            },
            {
                "rowIndex": 4,
                "columnIndex": 2,
                "value": "<p>100</p>"
            },
            {
                "rowIndex": 4,
                "columnIndex": 3,
                "value": "<p>160,253</p>"
            },
            {
                "rowIndex": 4,
                "columnIndex": 4,
                "value": "<p>100</p>"
            },
            {
                "rowIndex": 4,
                "columnIndex": 5,
                "value": "<p>161,062</p>"
            },
            {
                "rowIndex": 4,
                "columnIndex": 6,
                "value": "<p>100</p>"
            }
            ],
            [
            {
                "rowIndex": 5,
                "columnIndex": 0,
                "value": "<p>Impairment provisions</p>"
            },
            {
                "rowIndex": 5,
                "columnIndex": 1,
                "value": "<p>(564)</p>"
            },
            {
                "rowIndex": 5,
                "columnIndex": 2,
                "value": ""
            },
            {
                "rowIndex": 5,
                "columnIndex": 3,
                "value": "<p>(433)</p>"
            },
            {
                "rowIndex": 5,
                "columnIndex": 4,
                "value": ""
            },
            {
                "rowIndex": 5,
                "columnIndex": 5,
                "value": "<p>(344)</p>"
            },
            {
                "rowIndex": 5,
                "columnIndex": 6,
                "value": ""
            }
            ]
        ]
    }

### DEMO ###

You can find a demo site in the source.

`samples\Our.Umbraco.Tables.Demo`

**username**: admin@ry.com  
**password**: password1234