const path = require('path');
const fs = require('fs');

const input = fs.readFileSync(path.join(__dirname, 'input.txt'))
                .toString()
                .trim()
                .split('\n')
                .map(x => parseInt(x));

function count_increases(depth)
{                
    let count = 0;
    for (let i = depth; i < input.length; i++)
    {
        if (input[i-depth] < input[i]) count++;
    }
    return count;
}

console.log(count_increases(1));
console.log(count_increases(3));