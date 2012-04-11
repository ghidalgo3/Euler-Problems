#gustavo hidalgo
#gangstas
sumo = 0
#xrange like a boss, not range
for index in xrange(0,1000):
    #check if divisible by 3 or 5 and then increment sumo
    #apparently sum is reserved?
    if index%3 == 0 or index%5 == 0:
        sumo = sumo + index
print sumo
