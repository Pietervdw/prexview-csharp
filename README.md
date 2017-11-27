1. Sign up for an account at https://prexview.com/
2. Install the [Nuget package](https://www.nuget.org/packages/PrexView.NetStandard) OR Download the library.
3. Create your design on Prexview
4. Use the library like this:

```csharp

public async Task GenerateInvoice()
{
	var prex = new PrexView("--YOUR-API-KEY--");
	string data = @"{ xml-data-here }";
	string design = "new-9999"; // Design name on Prexview
	Enums.PrexViewOutput output = Enums.PrexViewOutput.pdf;
	Enums.PrexViewFormat format = Enums.PrexViewFormat.json;

	var fileBytes = await prex.Transform(format, data, design, output);
	System.IO.File.WriteAllBytes(@"C:\temp\invoice." + output, fileBytes);
}

```

Output can be one of the following
* html
* pdf
* png
* jpg

Input format can be one of two:
* json
* xml
