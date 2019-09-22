public ActionResult Events(DateTime? start, DateTime? end)
{

  var events = from ev in db.Events.AsEnumerable() where !(ev.end <= start || ev.start >= end) select ev;

  var result = events
  .Select(e => new JsonEvent() { 
      start = e.start.ToString("s"),
      end = e.end.ToString("s"),
      text = e.name,
      id = e.id.ToString()
  })
  .ToList();

  return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
} 