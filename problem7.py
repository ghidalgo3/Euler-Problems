primeList = [2]

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

test = 3
while len(primeList) < 10001:
    if factorize(test) == test:
        primeList.append(test)
    test+=1

print primeList[len(primeList)-1]
