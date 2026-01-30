# BFA Consulting - Blazor WebAssembly

Landing page moderna per BFA Consulting, convertita da React a Blazor WebAssembly.

## Struttura del Progetto

```
blazor-bfa/
├── Components/           # Componenti Razor riutilizzabili
│   ├── Navbar.razor      # Navigazione con glassmorphism
│   ├── Hero.razor        # Sezione hero con animazioni
│   ├── About.razor       # Chi Siamo con statistiche
│   ├── Services.razor    # Servizi offerti
│   ├── Projects.razor    # Carousel progetti
│   ├── Testimonials.razor # Testimonial slider
│   ├── Contact.razor     # Form contatti
│   └── Footer.razor      # Footer
├── Pages/
│   └── Home.razor        # Pagina principale
├── Shared/
│   └── MainLayout.razor  # Layout principale
├── wwwroot/
│   ├── css/app.css       # Stili globali
│   ├── js/app.js         # JavaScript interop (GSAP)
│   ├── images/           # Immagini
│   └── index.html        # Entry point
└── Program.cs            # Configurazione app
```

## Componenti Convertiti

| React Component | Blazor Component |
|----------------|------------------|
| Navbar.tsx | Navbar.razor |
| Hero.tsx | Hero.razor |
| About.tsx | About.razor + StatCircle.razor |
| Services.tsx | Services.razor + ServiceCard.razor |
| Projects.tsx | Projects.razor |
| Testimonials.tsx | Testimonials.razor |
| Contact.tsx | Contact.razor |
| Footer.tsx | Footer.razor |

## Differenze Chiave React → Blazor

### 1. Stato e Props
```csharp
// React
const [count, setCount] = useState(0);

// Blazor
@code {
    private int count = 0;
}
```

### 2. Eventi
```csharp
// React
onClick={() => handleClick()}

// Blazor
@onclick="HandleClick"
```

### 3. Riferimenti agli elementi
```csharp
// React
const ref = useRef(null);

// Blazor
@ref="elementRef"
```

### 4. Effetti/Animazioni
```csharp
// React - useEffect + GSAP
useEffect(() => { gsap.to(...) }, []);

// Blazor - JS Interop
await JSRuntime.InvokeVoidAsync("heroInterop.animate", headingRef, ...);
```

### 5. Stili CSS
- React: CSS-in-JS o CSS modules
- Blazor: **CSS isolato** (`.razor.css`) automatico

## Prerequisiti

- .NET 8.0 SDK
- Visual Studio 2022 o VS Code

## Come Eseguire

```bash
# Clona o scarica il progetto
cd blazor-bfa

# Ripristina i pacchetti
dotnet restore

# Esegui in modalità sviluppo
dotnet run

# Oppure build per produzione
dotnet publish -c Release
```

## Funzionalità Implementate

✅ Navigazione fissa con glassmorphism  
✅ Animazioni GSAP allo scroll  
✅ Statistiche circolari animate  
✅ Card servizi espandibili  
✅ Carousel progetti con navigazione  
✅ Slider testimonial auto-play  
✅ Form contatti con toast notification  
✅ Responsive design  
✅ CSS isolato per componenti  

## Librerie Esterne

- **GSAP** + ScrollTrigger: Animazioni (via CDN)
- **Inter** + **Fraunces**: Font Google

## Note

- Le animazioni GSAP sono gestite tramite JavaScript interop
- Il CSS è isolato per ogni componente (file `.razor.css`)
- Il progetto è configurato come PWA (Progressive Web App)
