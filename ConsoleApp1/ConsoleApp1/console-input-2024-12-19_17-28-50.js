const puppeteer = require('puppeteer');
const fs = require('fs');
const path = require('path');

// Function to take full-page screenshots
async function takeScreenshots(urls, outputFolder) {
    // Launch the browser
    const browser = await puppeteer.launch();

    // Ensure output folder exists
    if (!fs.existsSync(outputFolder)) {
        fs.mkdirSync(outputFolder, { recursive: true });
    }

    for (const url of urls) {
        try {
            // Open a new page
            const page = await browser.newPage();
            await page.goto(url, { waitUntil: 'load', timeout: 60000 }); // Wait for the page to load

            // Generate a valid filename
            const sanitizedUrl = url.replace(/https?:\/\//, '').replace(/\//g, '_');
            const fullScreenshotPath = path.join(outputFolder, `${sanitizedUrl}.png`);

            // Take a full-page screenshot
            await page.screenshot({ path: fullScreenshotPath, fullPage: true });
            console.log(`Full-page screenshot saved: ${fullScreenshotPath}`);

            // Close the page
            await page.close();
        } catch (error) {
            console.error(`Failed to take screenshot of ${url}: ${error}`);
        }
    }

    // Close the browser
    await browser.close();
}

// List of websites to take screenshots of
const websiteUrls = [
    'https://www.google.com',  // Google homepage
    'https://www.example.com', // Example domain
    'https://www.wikipedia.org' // Wikipedia homepage
];

// Folder to save screenshots
const outputDirectory = 'screenshots'; // Folder where screenshots will be saved

// Run the function
takeScreenshots(websiteUrls, outputDirectory);
