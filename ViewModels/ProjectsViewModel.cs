namespace BlazorBFA.ViewModels;

public class ProjectsViewModel
{
    public List<ProjectModel> Projects { get; } =
    [
        new() { Name = "Crotone", Province = "KR", Year = "2023" },
        new() { Name = "Isola di Capo Rizzuto", Province = "KR", Year = "2016" },
        new() { Name = "Taurianova", Province = "RC", Year = "2020" },
        new() { Name = "Castrovillari", Province = "CS", Year = "2022" },
        new() { Name = "Cirò Marina", Province = "KR", Year = "2021" },
        new() { Name = "Cropani", Province = "CZ", Year = "2018" },
        new() { Name = "Strongoli", Province = "KR", Year = "2017" },
        new() { Name = "Sersale", Province = "CZ", Year = "2020" },
        new() { Name = "Cirò", Province = "KR", Year = "2023" },
        new() { Name = "Amendolara", Province = "CS", Year = "2021" },
        new() { Name = "Guardia Piemontese", Province = "CS", Year = "2022" },
        new() { Name = "Francavilla Marittima", Province = "CS", Year = "2021" },
        new() { Name = "Nocara", Province = "CS", Year = "2021" },
        new() { Name = "Castroreggio", Province = "CS", Year = "2021" },
    ];
}

public class ProjectModel
{
    public string Name { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
}
