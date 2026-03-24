/* =====================================================
   BFA CONSULTING – app.js
   GSAP ScrollTrigger animations + utilities
   ===================================================== */

// ── Smooth scroll utility ──────────────────────────────
window.scrollToSection = function (sectionId) {
    const el = document.getElementById(sectionId);
    if (el) el.scrollIntoView({ behavior: 'smooth', block: 'start' });
};

window.scrollInterop = {
    scrollToElement: function (selector) {
        const el = document.querySelector(selector);
        if (el) el.scrollIntoView({ behavior: 'smooth' });
    }
};

// ── Navbar scroll detection ───────────────────────────
window.navbarInterop = {
    dotNetRef: null,
    _handler: null,

    initialize: function (dotNetRef) {
        this.dotNetRef = dotNetRef;
        this._handler = () => {
            dotNetRef.invokeMethodAsync('SetScrolled', window.scrollY > 60);
        };
        window.addEventListener('scroll', this._handler, { passive: true });
        this._handler();
    },

    dispose: function () {
        if (this._handler) window.removeEventListener('scroll', this._handler);
        this.dotNetRef = null;
    }
};

// ── GSAP ScrollTrigger setup ──────────────────────────
window.gsapAnimations = {
    initialized: false,

    init: function () {
        if (this.initialized) return;
        if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') return;

        gsap.registerPlugin(ScrollTrigger);

        // Respect prefers-reduced-motion
        const prefersReduced = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
        if (prefersReduced) {
            document.querySelectorAll('.gsap-fade-up, .gsap-fade-in, .gsap-slide-left, .gsap-slide-right, .gsap-scale-in')
                .forEach(el => {
                    el.style.opacity = '1';
                    el.style.transform = 'none';
                });
            return;
        }

        this.initialized = true;

        // ── fade-up (most common) ──
        gsap.utils.toArray('.gsap-fade-up').forEach((el, i) => {
            const delay = parseFloat(el.dataset.delay || 0);
            gsap.fromTo(el,
                { y: 40, opacity: 0 },
                {
                    y: 0, opacity: 1,
                    duration: 0.75,
                    delay: delay,
                    ease: 'power3.out',
                    scrollTrigger: {
                        trigger: el,
                        start: 'top 88%',
                        toggleActions: 'play none none none'
                    }
                }
            );
        });

        // ── fade-in ──
        gsap.utils.toArray('.gsap-fade-in').forEach(el => {
            gsap.fromTo(el,
                { opacity: 0 },
                {
                    opacity: 1,
                    duration: 0.7,
                    ease: 'power2.out',
                    scrollTrigger: {
                        trigger: el,
                        start: 'top 88%',
                        toggleActions: 'play none none none'
                    }
                }
            );
        });

        // ── slide from left ──
        gsap.utils.toArray('.gsap-slide-left').forEach(el => {
            gsap.fromTo(el,
                { x: -50, opacity: 0 },
                {
                    x: 0, opacity: 1,
                    duration: 0.8,
                    ease: 'power3.out',
                    scrollTrigger: {
                        trigger: el,
                        start: 'top 85%',
                        toggleActions: 'play none none none'
                    }
                }
            );
        });

        // ── slide from right ──
        gsap.utils.toArray('.gsap-slide-right').forEach(el => {
            gsap.fromTo(el,
                { x: 50, opacity: 0 },
                {
                    x: 0, opacity: 1,
                    duration: 0.8,
                    ease: 'power3.out',
                    scrollTrigger: {
                        trigger: el,
                        start: 'top 85%',
                        toggleActions: 'play none none none'
                    }
                }
            );
        });

        // ── scale in ──
        gsap.utils.toArray('.gsap-scale-in').forEach(el => {
            gsap.fromTo(el,
                { scale: 0.88, opacity: 0 },
                {
                    scale: 1, opacity: 1,
                    duration: 0.8,
                    ease: 'power3.out',
                    scrollTrigger: {
                        trigger: el,
                        start: 'top 85%',
                        toggleActions: 'play none none none'
                    }
                }
            );
        });
    }
};

// ── Hero entrance animations ──────────────────────────
window.heroAnimations = {
    init: function () {
        if (typeof gsap === 'undefined') return;

        const prefersReduced = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
        if (prefersReduced) return;

        const hero = document.getElementById('home');
        if (!hero) return;

        const items = hero.querySelectorAll('.gsap-fade-up');
        gsap.fromTo(items,
            { y: 35, opacity: 0 },
            {
                y: 0, opacity: 1,
                duration: 0.75,
                stagger: 0.15,
                ease: 'power3.out',
                delay: 0.25
            }
        );
    }
};

// ── Legacy interop stubs (kept for backwards-compat) ──
window.heroInterop        = { animate: () => {} };
window.aboutInterop       = { animate: () => {} };
window.statCircleInterop  = { animate: () => {} };
window.servicesInterop    = { animateHeader: () => {} };
window.serviceCardInterop = { animate: () => {} };
window.projectsInterop    = { animate: () => {}, scroll: () => {}, scrollToDot: () => {}, getScrollState: () => ({}) };
window.testimonialsInterop= { animate: () => {} };

window.contactInterop = {
    animate: () => {},
    showToast: function (title, message) {
        const toast = document.createElement('div');
        toast.style.cssText = `
            position: fixed; top: 1.25rem; left: 50%;
            transform: translateX(-50%) translateY(-120%);
            background: linear-gradient(135deg, #0369A1 0%, #14B8A6 100%);
            color: white; padding: 0.875rem 1.75rem;
            border-radius: 0.75rem;
            box-shadow: 0 8px 24px rgba(3,105,161,0.30);
            z-index: 9999; font-family: 'Plus Jakarta Sans', sans-serif;
            font-weight: 500; font-size: 0.9rem;
            transition: transform 0.35s cubic-bezier(0.16,1,0.3,1);
            max-width: 90vw; text-align: center;
        `;
        toast.innerHTML = `<strong>${title}</strong><br><span style="opacity:0.85;">${message}</span>`;
        document.body.appendChild(toast);
        requestAnimationFrame(() => {
            toast.style.transform = 'translateX(-50%) translateY(0)';
        });
        setTimeout(() => {
            toast.style.transform = 'translateX(-50%) translateY(-120%)';
            toast.style.opacity = '0';
            setTimeout(() => toast.remove(), 400);
        }, 3200);
    }
};

// ── Boot: run GSAP after Blazor renders ──────────────
// Blazor calls this after each navigation
window.blazorGsapBoot = function () {
    // Small delay to ensure DOM is painted
    setTimeout(() => window.gsapAnimations.init(), 120);
};

// Also run on DOMContentLoaded as fallback
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', () => setTimeout(() => window.gsapAnimations.init(), 300));
} else {
    setTimeout(() => window.gsapAnimations.init(), 300);
}
