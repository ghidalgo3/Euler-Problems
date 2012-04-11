#2520 is the smallest number that can be divided
#by each of the numbers from 1 to 10 without any remainder.

#What is the smallest positive number that is
#evenly divisible by all of the numbers from 1 to 20?

#crappy sqrt calculator
def sqrt(n):
    i = 0.0
    close = 0.1
    #approximation of order of magnitude for efficiency
    for x in xrange(100):
        if n%(10**x)==n:
            i = 10**((x-1)/2)
            gap = float(i)
            break
    while abs(n-i**2)>close:
        i += gap
        if i**2 > n:
            i -= gap
            gap /= 10
    return i

#returns the lowest prime factor of a number
#if prime, returns the number itself
def factorize(n):
    for x in xrange(2,1+int(sqrt(n))):
        if n%x == 0:
            return x
    return n


primeFactors = {
   2 : 0,
   3 : 0,
   5 : 0,
   7 : 0,
   11 : 0,
   13 : 0,
   17 : 0,
   19 : 0,
   }


#use only numbers 1 thru 20, only works for this assignment
#returns a dictionary of the factors of n
def factorToList(n):
    localFactors = {
       2 : 0,
       3 : 0,
       5 : 0,
       7 : 0,
       11 : 0,
       13 : 0,
       17 : 0,
       19 : 0,
       }
    a = 0
    while n != 1:
        a = factorize(n)
        localFactors[a] = localFactors[a] + 1
        n /= a
    return localFactors

localFactors = {
    2 : 0,
    3 : 0,
    5 : 0,
    7 : 0,
    11 : 0,
    13 : 0,
    17 : 0,
    19 : 0,
    }

for x in xrange(20,1,-1):
    localFactors = factorToList(x)
    for factor in primeFactors:
        if localFactors[factor] > primeFactors[factor]:
            primeFactors[factor] = localFactors[factor]

product = 1

for numbers in primeFactors:
    product *= numbers**primeFactors[numbers]

print product

for test in range(1,21):
    if product%test != 0:
        print "lol"
        

        
    


