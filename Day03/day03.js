const path = require('path');
const fs = require('fs');

const input = fs.readFileSync(path.join(__dirname, 'input.txt')).toString().trim()
                .split('\n');


function partone()
{
    let count = new Array(input[0].length).fill(0);
    for (let i = 0; i < input.length; i++)
    {
        for (let j = 0; j < count.length; j++)
        {
            if (input[i][j] === '1') count[j]++;
        }
    }

    let gamma = '';
    let epsilon = '';

    for (let i = 0; i < count.length; i++)
    {
        if (count[i] > input.length / 2)
        {
            gamma = gamma.concat('1');
            epsilon = epsilon.concat('0');
        }
        else
        {
            gamma = gamma.concat('0');
            epsilon = epsilon.concat('1');
        }
    }

    console.log(parseInt(gamma,2) * parseInt(epsilon,2));
}

function parttwo()
{
    let ones = input.filter(x => x[0] === '1');
    let zeros = input.filter(x => x[0] === '0');

    let oxygen_rating = [];
    let co2_rating = [];

    if (ones.length > zeros.length)
    {
        oxygen_rating = ones.slice();
        co2_rating = zeros.slice();
    }
    else 
    {
        oxygen_rating = zeros.slice();
        co2_rating = ones.slice();
    }
    for (let i = 1; i < input[0].length; i++)
    {
        if (oxygen_rating.length > 1)
        {
            ones = oxygen_rating.filter(x => x[i] === '1');
            zeros = oxygen_rating.filter(x => x[i] === '0');

            if (ones.length >= zeros.length)
            {
                oxygen_rating = ones.slice();
            }
            else 
            {
                oxygen_rating = zeros.slice();
            }
        }
        
        if (co2_rating.length > 1)
        {
            ones = co2_rating.filter(x => x[i] === '1');
            zeros = co2_rating.filter(x => x[i] === '0');

            if (ones.length < zeros.length)
            {
                co2_rating = ones.slice();
            }
            else 
            {
                co2_rating = zeros.slice();
            }
        }
    }

    console.log(parseInt(oxygen_rating[0], 2) * parseInt(co2_rating[0], 2));
}

partone();
parttwo();