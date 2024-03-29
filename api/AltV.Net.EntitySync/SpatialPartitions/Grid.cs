using System;
using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync.SpatialPartitions
{
    public class Grid : SpatialPartition
    {
        private static readonly float Tolerance = 0.013F; //0.01318359375F;

        // x-index, y-index, col shapes
        private readonly IEntity[][][] entityAreas;

        private readonly int maxX;

        private readonly int maxY;

        private readonly int areaSize;

        private readonly int xOffset;

        private readonly int yOffset;

        private readonly int maxXAreaIndex;
        
        private readonly int maxYAreaIndex;
        
        private readonly IList<IEntity> entities = new List<IEntity>();

        /// <summary>
        /// The constructor of the grid spatial partition algorithm
        /// </summary>
        /// <param name="maxX">The max x value</param>
        /// <param name="maxY">The max y value</param>
        /// <param name="areaSize">The Size of a grid area</param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        public Grid(int maxX, int maxY, int areaSize, int xOffset, int yOffset)
        {
            this.maxX = maxX + xOffset;
            this.maxY = maxY + yOffset;
            this.areaSize = areaSize;
            this.xOffset = xOffset;
            this.yOffset = yOffset;

            maxXAreaIndex = this.maxX / areaSize;
            maxYAreaIndex = this.maxY / areaSize;

            entityAreas = new IEntity[maxXAreaIndex][][];

            for (var i = 0; i < maxXAreaIndex; i++)
            {
                entityAreas[i] = new IEntity[maxYAreaIndex][];
                for (var j = 0; j < maxYAreaIndex; j++)
                {
                    entityAreas[i][j] = new IEntity[0];
                }
            }
        }

        public override void Add(IEntity entity)
        {
            var entityPositionX = entity.Position.X + xOffset;
            var entityPositionY = entity.Position.Y + yOffset;
            var range = entity.Range;
            
            var squareMaxX = entityPositionX + range;
            var squareMaxY = entityPositionY + range;
            var squareMinX = entityPositionX - range;
            var squareMinY = entityPositionY - range;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var startingYIndex = (int) Math.Floor(squareMinY / areaSize);
            // We now define starting x index to start filling
            var startingXIndex = (int) Math.Floor(squareMinX / areaSize);
            // Also define stopping indexes
            var stoppingYIndex =
                (int) Math.Ceiling(squareMaxY / areaSize);
            var stoppingXIndex =
                (int) Math.Ceiling(squareMaxX / areaSize);

            if (range == 0 || startingYIndex < 0 || startingXIndex < 0 ||
                stoppingYIndex >= maxYAreaIndex ||
                stoppingXIndex >= maxXAreaIndex) return;

            // Now fill all areas from min {x, y} to max {x, y}
            for (var i = startingYIndex; i <= stoppingYIndex; i++)
            {
                for (var j = startingXIndex; j <= stoppingXIndex; j++)
                {
                    var length = entityAreas[j][i].Length;
                    Array.Resize(ref entityAreas[j][i], length + 1);
                    entityAreas[j][i][length] = entity;
                }
            }
        }

        public override void Remove(IEntity entity)
        {
            var entityPositionX = entity.Position.X + xOffset;
            var entityPositionY = entity.Position.Y + yOffset;
            var range = entity.Range;
            var id = entity.Id;
            var type = entity.Type;
            
            var squareMaxX = entityPositionX + range;
            var squareMaxY = entityPositionY + range;
            var squareMinX = entityPositionX - range;
            var squareMinY = entityPositionY - range;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var startingYIndex = (int) Math.Floor(squareMinY / areaSize);
            // We now define starting x index to start filling
            var startingXIndex = (int) Math.Floor(squareMinX / areaSize);
            // Also define stopping indexes
            var stoppingYIndex =
                (int) Math.Ceiling(squareMaxY / areaSize);
            var stoppingXIndex =
                (int) Math.Ceiling(squareMaxX / areaSize);
            
            if (range == 0 || startingYIndex < 0 || startingXIndex < 0 ||
                stoppingYIndex > maxYAreaIndex ||
                stoppingXIndex > maxXAreaIndex) return;
            
            // Now remove entity from all areas from min {x, y} to max {x, y}
            for (var i = startingYIndex; i <= stoppingYIndex; i++)
            {
                for (var j = startingXIndex; j <= stoppingXIndex; j++)
                {
                    var arr = entityAreas[j][i];
                    var length = arr.Length;
                    int k;
                    var found = false;
                    for (k = 0; k < length; k++)
                    {
                        var currEntity = arr[k];
                        if (currEntity.Id != id || currEntity.Type != type) continue;
                        found = true;
                        break;
                    }

                    if (!found) continue;
                    var newLength = length - 1;
                    for (var l = k; l < newLength; l++)
                    {
                        arr[l] = arr[l + 1];
                    }

                    Array.Resize(ref entityAreas[j][i], newLength);
                }
            }
        }

        public override void UpdateEntityPosition(IEntity entity, in Vector3 oldPosition, in Vector3 newPosition)
        {
            var oldEntityPositionX = oldPosition.X + xOffset;
            var oldEntityPositionY = oldPosition.Y + yOffset;
            var newEntityPositionX = newPosition.X + xOffset;
            var newEntityPositionY = newPosition.Y + yOffset;
            var range = entity.Range;
            var id = entity.Id;
            var type = entity.Type;
            
            var oldSquareMaxX = oldEntityPositionX + range;
            var oldSquareMaxY = oldEntityPositionY + range;
            var oldSquareMinX = oldEntityPositionX - range;
            var oldSquareMinY = oldEntityPositionY - range;
            
            var newSquareMaxX = newEntityPositionX + range;
            var newSquareMaxY = newEntityPositionY + range;
            var newSquareMinX = newEntityPositionX - range;
            var newSquareMinY = newEntityPositionY - range;
            
            if (range == 0 || oldSquareMinX < 0 || oldSquareMinY < 0 ||
                oldSquareMaxX > maxX ||
                oldSquareMaxY > maxY || newSquareMinX < 0 || newSquareMinY < 0 ||
                newSquareMaxX > maxX ||
                newSquareMaxY > maxY) return;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var oldStartingYIndex = (int) Math.Floor(oldSquareMinY / areaSize);
            // We now define starting x index to start filling
            var oldStartingXIndex = (int) Math.Floor(oldSquareMinX / areaSize);
            // Also define stopping indexes
            var oldStoppingYIndex =
                (int) Math.Ceiling(oldSquareMaxY / areaSize);
            var oldStoppingXIndex =
                (int) Math.Ceiling(oldSquareMaxX / areaSize);

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var newStartingYIndex = (int) Math.Floor(newSquareMinY / areaSize);
            // We now define starting x index to start filling
            var newStartingXIndex = (int) Math.Floor(newSquareMinX / areaSize);
            // Also define stopping indexes
            var newStoppingYIndex =
                (int) Math.Ceiling(newSquareMaxY / areaSize);
            var newStoppingXIndex =
                (int) Math.Ceiling(newSquareMaxX / areaSize);

            //TODO: do later checking for overlaps between the grid areas in the two dimensional array
            //  --    --    --    --   
            // |xy|  |xy|  |yy|  |  |    
            // |yx|  |yx|  |yy|  |  |
            //  --    --    --    --  
            //
            //  --    --    --    --   
            // |xy|  |xy|  |yy|  |  |    
            // |yx|  |yx|  |yy|  |  |
            //  --    --    --    --  
            //
            //  --    --    --    --   
            // |yy|  |yy|  |yy|  |  |    
            // |yy|  |yy|  |yy|  |  |
            //  --    --    --    --  
            //
            //  --    --    --    --   
            // |  |  |  |  |  |  |  |    
            // |  |  |  |  |  |  |  |
            //  --    --    --    --  
            // Now we have to check if some of the (oldStartingYIndex, oldStoppingYIndex) areas are inside (newStartingYIndex, newStoppingYIndex)
            // Now we have to check if some of the (oldStartingXIndex, oldStoppingXIndex) areas are inside (newStartingXIndex, newStoppingXIndex)


            for (var i = oldStartingYIndex; i <= oldStoppingYIndex; i++)
            {
                for (var j = oldStartingXIndex; j <= oldStoppingXIndex; j++)
                {
                    //TODO: Now we check if (i,j) is inside the new position range, so we don't have to delete it
                    var arr = entityAreas[j][i];
                    var length = arr.Length;
                    int k;
                    var found = false;
                    for (k = 0; k < length; k++)
                    {
                        var currEntity = arr[k];
                        if (currEntity.Id != id || currEntity.Type != type) continue;
                        found = true;
                        break;
                    }

                    if (!found) continue;
                    var newLength = length - 1;
                    for (var l = k; l < newLength; l++)
                    {
                        arr[l] = arr[l + 1];
                    }

                    Array.Resize(ref entityAreas[j][i], newLength);
                }
            }

            for (var i = newStartingYIndex; i <= newStoppingYIndex; i++)
            {
                for (var j = newStartingXIndex; j <= newStoppingXIndex; j++)
                {
                    var length = entityAreas[j][i].Length;
                    Array.Resize(ref entityAreas[j][i], length + 1);
                    entityAreas[j][i][length] = entity;
                }
            }
        }

        public override void UpdateEntityRange(IEntity entity, uint oldRange, uint newRange)
        {
            var entityPositionX = entity.Position.X + xOffset;
            var entityPositionY = entity.Position.Y + yOffset;
            var id = entity.Id;
            var type = entity.Type;
            
            var oldSquareMaxX = entityPositionX + oldRange;
            var oldSquareMaxY = entityPositionY + oldRange;
            var oldSquareMinX = entityPositionX - oldRange;
            var oldSquareMinY = entityPositionY - oldRange;
            
            var newSquareMaxX = entityPositionX + newRange;
            var newSquareMaxY = entityPositionY + newRange;
            var newSquareMinX = entityPositionX - newRange;
            var newSquareMinY = entityPositionY - newRange;
            
            if (newRange == 0 || oldSquareMinX < 0 || oldSquareMinY < 0 ||
                oldSquareMaxX > maxX ||
                oldSquareMaxY > maxY || 
                newSquareMinX < 0 || newSquareMinY < 0 ||
                newSquareMaxX > maxX ||
                newSquareMaxY > maxY) return;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var oldStartingYIndex = (int) Math.Floor(oldSquareMinY / areaSize);
            // We now define starting x index to start filling
            var oldStartingXIndex = (int) Math.Floor(oldSquareMinX / areaSize);
            // Also define stopping indexes
            var oldStoppingYIndex =
                (int) Math.Ceiling(oldSquareMaxY / areaSize);
            var oldStoppingXIndex =
                (int) Math.Ceiling(oldSquareMaxX / areaSize);

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var newStartingYIndex = (int) Math.Floor(newSquareMinY / areaSize);
            // We now define starting x index to start filling
            var newStartingXIndex = (int) Math.Floor(newSquareMinX / areaSize);
            // Also define stopping indexes
            var newStoppingYIndex =
                (int) Math.Ceiling(newSquareMaxY / areaSize);
            var newStoppingXIndex =
                (int) Math.Ceiling(newSquareMaxX / areaSize);

            for (var i = oldStartingYIndex; i <= oldStoppingYIndex; i++)
            {
                for (var j = oldStartingXIndex; j <= oldStoppingXIndex; j++)
                {
                    //TODO: Now we check if (i,j) is inside the new position range, so we don't have to delete it
                    var arr = entityAreas[j][i];
                    var length = arr.Length;
                    int k;
                    var found = false;
                    for (k = 0; k < length; k++)
                    {
                        var currEntity = arr[k];
                        if (currEntity.Id != id || currEntity.Type != type) continue;
                        found = true;
                        break;
                    }

                    if (!found) continue;
                    var newLength = length - 1;
                    for (var l = k; l < newLength; l++)
                    {
                        arr[l] = arr[l + 1];
                    }

                    Array.Resize(ref entityAreas[j][i], newLength);
                }
            }

            for (var i = newStartingYIndex; i <= newStoppingYIndex; i++)
            {
                for (var j = newStartingXIndex; j <= newStoppingXIndex; j++)
                {
                    var length = entityAreas[j][i].Length;
                    Array.Resize(ref entityAreas[j][i], length + 1);
                    entityAreas[j][i][length] = entity;
                }
            }
        }

        public override void UpdateEntityDimension(IEntity entity, int oldDimension, int newDimension)
        {
            // This algorithm doesn't has different memory layout depending on dimension
        }

        /*
        X can see only X
        -X can see 0 and -X
        0 can't see -X and X
        */
        private static bool CanSeeOtherDimension(int dimension, int otherDimension)
        {
            if (dimension > 0) return dimension == otherDimension || otherDimension == int.MinValue;
            if (dimension < 0) return otherDimension == 0 || dimension == otherDimension || otherDimension == int.MinValue;
            return otherDimension == 0 || otherDimension == int.MinValue;
        }

        //TODO: check if we can find a better way to pass a position and e.g. improve performance of this method by return type ect.
        public override IList<IEntity> Find(Vector3 position, int dimension)
        {
            var posX = position.X + xOffset;
            var posY = position.Y + yOffset;

            var xIndex = Math.Max(Math.Min((int) Math.Floor(posX / areaSize), maxXAreaIndex - 1), 0);

            var yIndex = Math.Max(Math.Min((int) Math.Floor(posY / areaSize), maxYAreaIndex - 1), 0);

            entities.Clear();
            
            // x2 and y2 only required for complete exact range check

            /*var x2Index = (int) Math.Ceiling(posX / areaSize);

            var y2Index = (int) Math.Ceiling(posY / areaSize);*/

            var areaEntities = entityAreas[xIndex][yIndex];

            for (int j = 0, innerLength = areaEntities.Length; j < innerLength; j++)
            {
                var entity = areaEntities[j];
                var distance = Vector3.DistanceSquared(entity.Position, position);
                if (distance > entity.RangeSquared ||
                    !CanSeeOtherDimension(dimension, entity.Dimension)) continue;
                entity.LastStreamInRange = distance;
                entities.Add(entity);
            }

            return entities;

            /*if (xIndex != x2Index && yIndex == y2Index)
            {
                var innerAreaEntities = entityAreas[x2Index][yIndex];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
            } else if (xIndex == x2Index && yIndex != y2Index)
            {
                var innerAreaEntities = entityAreas[xIndex][y2Index];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
            } else if (xIndex != x2Index && yIndex != y2Index)
            {
                var innerAreaEntities = entityAreas[x2Index][yIndex];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
                
                innerAreaEntities = entityAreas[x2Index][y2Index];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
                
                innerAreaEntities = entityAreas[xIndex][y2Index];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
            }*/
        }
    }
}