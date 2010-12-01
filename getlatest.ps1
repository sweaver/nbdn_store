param($NewBranch)

git add -A
git commit
git checkout master
git checkout -b $NewBranch
git pull jp master

