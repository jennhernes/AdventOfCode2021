const path = require('path');
const fs = require('fs');

const input = fs.readFileSync(path.join(__dirname, 'input.txt')).toString().trim()
                .split('\n').map(x => x.split(' '))
        
let pos = [0,0,0];
for (const direction of input)
{
    if (direction[0] === 'forward')
    {
        pos[0] += parseInt(direction[1]);
        pos[1] += parseInt(direction[1]) * pos[2];
    }
    else if (direction[0] === 'down')
    {
        // pos[1] += parseInt(d[1]);
        pos[2] += parseInt(direction[1]);
    }
    else if (direction[0] === 'up')
    {
        // pos[1] -= parseInt(d[1]);
        pos[2] -= parseInt(direction[1]);
    }
}
console.log(pos[0]*pos[1]);