(
    () => {
        var newTitle = document.title + " _ ";

        setInterval(() => {
                newTitle = newTitle.substring(1) + newTitle.charAt(0);
                document.title = newTitle;
            },200
        );
    }
)();

document.addEventListener("click",
    (e) => {
        const button = e.target.closest('[data-action="show-date"]');
        const out = button?.closest('.footer-partial')?.querySelector('[data-output="date"]');
        if (out) out.textContent = new Date().toLocaleString();
    }
);