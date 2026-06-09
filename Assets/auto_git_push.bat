@echo off
cd /d "%~dp0"
git add .
git commit -m "Automated push on Unity close"
git push