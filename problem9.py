def sqrt(n):
    i = 0.0
    close = 0.01
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

squares = []
y = 1
for x in xrange(1,1000):
    squares.append(x**2)

pytSquares = set(squares)
y = z = 0
end = False
for x in xrange(len(squares)-1,0,-1):
    y = x
    while y > 0:
        z = squares[x] - squares[y]
        #here is where we check if a square is the sum of two lesser squares
        #simultaenously we check if a+b+c = 1000
        #nice usage of set functionality
        if z in pytSquares and (sqrt(squares[x]) + sqrt(squares[y]) + sqrt(z) == 1000):
            print int(sqrt(squares[x])*sqrt(squares[y])*sqrt(z))
            end = True
            break
        y-=1
    if end == True:
        break
        
    
